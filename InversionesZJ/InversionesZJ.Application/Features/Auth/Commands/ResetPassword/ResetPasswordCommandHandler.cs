using BC = BCrypt.Net.BCrypt;
using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;
using InversionesZJ.Domain.Enums.Login;

namespace InversionesZJ.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, GenericResponse>
{
    private readonly IUserRepository _userRepository;

    public ResetPasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GenericResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var resetToken = await _userRepository.GetPasswordResetTokenAsync(request.Token);

        var error = Validate(resetToken);
        if (error != ResetPasswordError.None)
            return new GenericResponse
            {
                Success = false,
                ResponseCode = "400",
                ResponseMessage = GetErrorMessage(error)
            };

        // Cambiar la contraseña
        var user = resetToken!.User;
        user.PasswordHash = BC.HashPassword(request.NewPassword);
        user.FailedAttempts = 0;
        user.LockedUntil = null;
        await _userRepository.UpdateAsync(user, cancellationToken);

        // Quemar el token
        resetToken.IsUsed = true;
        await _userRepository.UpdatePasswordResetTokenAsync(resetToken);

        return new GenericResponse
        {
            Success = true,
            ResponseCode = "200",
            ResponseMessage = "Password updated successfully"
        };
    }

    private ResetPasswordError Validate(Domain.Entities.Security.PasswordResetToken? token)
    {
        if (token is null)
            return ResetPasswordError.NotFound;

        if (token.IsUsed)
            return ResetPasswordError.AlreadyUsed;

        if (token.ExpiresAt < DateTime.UtcNow)
            return ResetPasswordError.Expired;

        return ResetPasswordError.None;
    }

    private string GetErrorMessage(ResetPasswordError error) => error switch
    {
        ResetPasswordError.NotFound => "Invalid or non-existent link",
        ResetPasswordError.AlreadyUsed => "This link has already been used",
        ResetPasswordError.Expired => "This link has expired",
        _ => "Unknown error"
    };
}