using BC = BCrypt.Net.BCrypt;
using MediatR;
using InversionesZJ.Application.DTO.Auth;
using InversionesZJ.Domain.Enums.Login;
using InversionesZJ.Domain.Interfaces.Roles;
using InversionesZJ.Domain.Entities.Security;

namespace InversionesZJ.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

        var loggedUser = new LoggedUserDto
        {
            Id = user.Id,
            Username = user.Username,
            FullName = user.FullName,
            Email = user.Email,
            Roles = user.userRoles.Select(x => x.Role.NameRole).ToList()
        };

        return new LoginResponse
        {
            Success = true,
            ResponseObject = loggedUser,
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