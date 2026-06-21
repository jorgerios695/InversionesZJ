using InversionesZJ.Application.DTO.Users;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Queries.GetRoles;

public class GetRolesQuery : IRequest<List<RoleListDto>>
{
}