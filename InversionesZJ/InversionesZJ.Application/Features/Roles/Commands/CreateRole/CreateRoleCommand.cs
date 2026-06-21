using InversionesZJ.Application.DTO.Roles;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<GenericResponse>
{
    public CreateRoleDto RoleDto { get; set; } = new();
}