using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommand : IRequest<GenericResponse>
{
    public string Username { get; set; } = string.Empty;
}