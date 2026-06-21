using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Commands.ToggleRoleStatus;

public class ToggleRoleStatusCommandHandler : IRequestHandler<ToggleRoleStatusCommand, GenericResponse>
{
    private readonly IRoleRepository _roleRepository;

    public ToggleRoleStatusCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<GenericResponse> Handle(ToggleRoleStatusCommand request, CancellationToken cancellationToken)
    {
        await _roleRepository.ToggleStatusAsync(request.Id);
        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Status updated successfully" };
    }
}