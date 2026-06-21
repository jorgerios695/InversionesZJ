using InversionesZJ.Application.DTO.Roles;
using InversionesZJ.Application.Features.Roles.Commands.CreateRole;
using InversionesZJ.Application.Features.Roles.Commands.ToggleRoleStatus;
using InversionesZJ.Application.Features.Roles.Commands.UpdateRole;
using InversionesZJ.Application.Features.Roles.Queries.GetAllRoles;
using InversionesZJ.Application.Features.Roles.Queries.GetRoleById;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Web.Services.Roles;

public class RoleService
{
    private readonly IMediator _mediator;

    public RoleService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<RoleDetailDto>> GetAllRolesAsync()
        => await _mediator.Send(new GetAllRolesQuery());

    public async Task<RoleDetailDto?> GetRoleByIdAsync(long id)
        => await _mediator.Send(new GetRoleByIdQuery { Id = id });

    public async Task<GenericResponse> CreateRoleAsync(CreateRoleDto dto)
        => await _mediator.Send(new CreateRoleCommand { RoleDto = dto });

    public async Task<GenericResponse> UpdateRoleAsync(UpdateRoleDto dto)
        => await _mediator.Send(new UpdateRoleCommand { RoleDto = dto });

    public async Task<GenericResponse> ToggleRoleStatusAsync(long id)
        => await _mediator.Send(new ToggleRoleStatusCommand { Id = id });
}