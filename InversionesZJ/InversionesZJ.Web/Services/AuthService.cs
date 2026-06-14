using InversionesZJ.Application.Features.Auth.Commands.Login;
using InversionesZJ.Application.DTO.Auth;
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
}