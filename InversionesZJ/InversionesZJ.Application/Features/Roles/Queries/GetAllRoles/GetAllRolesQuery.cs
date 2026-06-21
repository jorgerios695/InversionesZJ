using InversionesZJ.Application.DTO.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQuery : IRequest<List<RoleDetailDto>>
{
}