using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommand : IRequest<GenericResponse>
{
    public string Token { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}