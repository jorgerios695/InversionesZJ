using InversionesZJ.Application.DTO.Roles;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommand : IRequest<GenericResponse>
{
    public UpdateRoleDto RoleDto { get; set; } = new();
}