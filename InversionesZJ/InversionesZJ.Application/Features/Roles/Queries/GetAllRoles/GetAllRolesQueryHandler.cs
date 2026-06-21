using InversionesZJ.Application.DTO.Roles;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleDetailDto>>
{
    private readonly IRoleRepository _roleRepository;

    public GetAllRolesQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<List<RoleDetailDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllRolesAsync();

        return roles.Select(r => new RoleDetailDto
        {
            Id = r.Id,
            Name = r.NameRole,
            Description = r.Description,
            IsActive = r.IsActive
        }).ToList();
    }
}