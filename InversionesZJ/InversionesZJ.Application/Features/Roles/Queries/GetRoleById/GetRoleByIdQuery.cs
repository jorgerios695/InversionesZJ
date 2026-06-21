using InversionesZJ.Application.DTO.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery : IRequest<RoleDetailDto?>
{
    public long Id { get; set; }
}