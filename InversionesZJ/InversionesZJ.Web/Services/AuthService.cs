using InversionesZJ.Application.DTO.Auth;
using InversionesZJ.Application.Features.Auth.Commands.ForgotPassword;
using InversionesZJ.Application.Features.Auth.Commands.Login;
using InversionesZJ.Application.Features.Auth.Commands.ResetPassword;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Web.Services;

public class AuthService
{
    private readonly IMediator _mediator;

    public AuthService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<LoginResponse> LoginAsync(string username, string password)
    {
        var loginDto = new LoginDto
        {
            Username = username,
            Password = password
        };

        return await _mediator.Send(new LoginCommand() { loginDto = loginDto });
    }
    public async Task<GenericResponse> ForgotPasswordAsync(string username)
    {
        var command = new ForgotPasswordCommand { Username = username };
        return await _mediator.Send(command);
    }
    public async Task<GenericResponse> ResetPasswordAsync(string token, string newPassword)
    {
        var command = new ResetPasswordCommand { Token = token, NewPassword = newPassword };
        return await _mediator.Send(command);
    }
}