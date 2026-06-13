using BC = BCrypt.Net.BCrypt;
using InversionesZJ.Application.Interfaces;
using InversionesZJ.Domain.Interfaces;
using MediatR;
using InversionesZJ.Domain.DTO.Auth;
using InversionesZJ.Domain.Entities;

namespace InversionesZJ.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var dto = request.loginDto; 
        var user = await _userRepository.GetByUsernameAsync(dto.Username);
        var errors = await Validate(user, dto, cancellationToken);

        if (errors.Any())
            return new LoginResponse
            {
                Success = false,
                ResponseCode = "400",
                ResponseMessage = string.Join(", ", errors.Select(e => $"{e.Property} {e.Message}"))
            };


        user.FailedAttempts = 0;
        user.LockedUntil = null;
        await _userRepository.UpdateAsync(user, cancellationToken);

        var roles = user.userRoles.Select(x => x.Role.NameRole).ToList();
        var token = _jwtService.GenerateToken(user, roles);

        return new LoginResponse
        {
            Success = true,
            ResponseObject = token,
            ResponseCode = "200",
            ResponseMessage = "Login successful"
        };
    
    }


    private async Task<List<(string Property, string Message)>> Validate (User user, LoginDto dto, CancellationToken ct)
    {
        var errors  = new List<(string ,string)>();

        if (user is null)
            errors.Add(("username", "Invalid username or password"));

        if (user.LockedUntil.HasValue && user.LockedUntil > DateTime.UtcNow)
            errors.Add(("User", $"User blocked until {user.LockedUntil.Value:HH:mm}"));
           
        bool validPassword = BC.Verify(dto.Password, user.PasswordHash);

        if (!validPassword)
        {
            user.FailedAttempts++;

            if (user.FailedAttempts >= 5)
            {
                user.LockedUntil = DateTime.UtcNow.AddMinutes(15);
                user.FailedAttempts = 0;
            }

            await _userRepository.UpdateAsync(user, ct);
            errors.Add(("User", "Invalid username or password")); 
        }
        return errors;
    }
}