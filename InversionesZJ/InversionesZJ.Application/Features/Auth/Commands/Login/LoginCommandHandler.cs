using BC = BCrypt.Net.BCrypt;
using InversionesZJ.Application.Interfaces;
using InversionesZJ.Domain.Interfaces;
using MediatR;
using InversionesZJ.Domain.DTO.Auth;
using InversionesZJ.Domain.Entities;
using InversionesZJ.Domain.Enums.Login;

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

        var error = Validate(user, dto);

        if (error != LoginErrorType.None)
        {
            if (error == LoginErrorType.InvalidPassword)
            {
                user.FailedAttempts++;

                if (user.FailedAttempts >= 5)
                {
                    user.LockedUntil = DateTime.UtcNow.AddMinutes(15);
                    user.FailedAttempts = 0;
                }

                await _userRepository.UpdateAsync(user, cancellationToken);
            }

            return new LoginResponse
            {
                Success = false,
                ResponseCode = "400",
                ResponseMessage = GetErrorMessage(error, user)
            };
        }

        // Login exitoso
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

    private string GetErrorMessage(LoginErrorType error, User user) => error switch
    {
        LoginErrorType.UserNotFound => "Invalid username or password",
        LoginErrorType.InvalidPassword => "Invalid username or password",
        LoginErrorType.UserLocked => $"User blocked until {user.LockedUntil!.Value:HH:mm}",
        _ => "Unknown error"
    };


    private LoginErrorType Validate(User user, LoginDto dto)
    {
        if (user is null)
            return LoginErrorType.UserNotFound;

        if (user.LockedUntil.HasValue && user.LockedUntil > DateTime.UtcNow)
            return LoginErrorType.UserLocked;

        if (!BC.Verify(dto.Password, user.PasswordHash))
            return LoginErrorType.InvalidPassword;

        return LoginErrorType.None;
    }
}