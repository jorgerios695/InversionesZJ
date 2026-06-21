using InversionesZJ.Application.Common;
using InversionesZJ.Application.Interfaces;
using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InversionesZJ.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, GenericResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly AppSettings _appSettings;
    private readonly ILogger<ForgotPasswordCommandHandler> _logger;

    public ForgotPasswordCommandHandler(
        IUserRepository userRepository,
        IEmailService emailService,
        IOptions<AppSettings> appSettings,
        ILogger<ForgotPasswordCommandHandler> logger)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _appSettings = appSettings.Value;
        _logger = logger;
    }

    public async Task<GenericResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);

        if (user is null || string.IsNullOrEmpty(user.Email))
        {
            _logger.LogWarning("Solicitud de recuperación para usuario inexistente o sin email: {Username}", request.Username);

            return new GenericResponse
            {
                Success = true,
                ResponseCode = "200",
                ResponseMessage = "If the account exists, a recovery email has been sent"
            };
        }

        var token = Guid.NewGuid().ToString("N");

        var resetToken = new PasswordResetToken
        {
            UserId = user.Id,
            Token = token,
            ExpiresAt = DateTime.UtcNow.AddHours(1),
            IsUsed = false,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true
        };

        await _userRepository.AddPasswordResetTokenAsync(resetToken);

        var resetLink = $"{_appSettings.BaseUrl}/reset-password?token={token}";

        var body = $@"
            <h2>Recuperación de contraseña</h2>
            <p>Hola {user.FullName},</p>
            <p>Recibimos una solicitud para restablecer tu contraseña. Haz clic en el siguiente enlace:</p>
            <p><a href='{resetLink}'>Restablecer contraseña</a></p>
            <p>Este enlace expira en 1 hora. Si no solicitaste esto, ignora este correo.</p>";

        await _emailService.SendAsync(user.Email, "Recuperación de contraseña - InversionesZJ", body, cancellationToken);

        _logger.LogInformation("Correo de recuperación enviado al usuario {Username} en {Email}", user.Username, user.Email);

        return new GenericResponse
        {
            Success = true,
            ResponseCode = "200",
            ResponseMessage = "If the account exists, a recovery email has been sent"
        };
    }
}