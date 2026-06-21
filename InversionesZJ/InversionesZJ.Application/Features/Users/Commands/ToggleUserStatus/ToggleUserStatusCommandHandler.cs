using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Commands.ToggleUserStatus;

public class ToggleUserStatusCommandHandler : IRequestHandler<ToggleUserStatusCommand, GenericResponse>
{
    private readonly IUserRepository _userRepository;

    public ToggleUserStatusCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GenericResponse> Handle(ToggleUserStatusCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.ToggleStatusAsync(request.Id);

        return new GenericResponse
        {
            Success = true,
            ResponseCode = "200",
            ResponseMessage = "Status updated successfully"
        };
    }
}