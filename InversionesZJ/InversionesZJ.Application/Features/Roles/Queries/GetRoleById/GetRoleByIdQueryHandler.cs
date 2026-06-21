using InversionesZJ.Application.DTO.Roles;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDetailDto?>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<RoleDetailDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.Id);

        if (role is null)
            return null;

        return new RoleDetailDto
        {
            Id = role.Id,
            Name = role.NameRole,
            Description = role.Description,
            IsActive = role.IsActive
        };
    }
}