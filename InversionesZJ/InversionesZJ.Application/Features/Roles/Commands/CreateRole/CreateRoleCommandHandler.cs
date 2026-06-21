using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, GenericResponse>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<GenericResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var dto = request.RoleDto;

        if (string.IsNullOrWhiteSpace(dto.Name))
            return Fail("Role name is required");

        if (await _roleRepository.ExistsByNameAsync(dto.Name))
            return Fail("Role name already exists");

        var role = new Role
        {
            NameRole = dto.Name,
            Description = dto.Description,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        await _roleRepository.AddAsync(role, cancellationToken);

        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Role created successfully" };
    }

    private GenericResponse Fail(string message) => new() { Success = false, ResponseCode = "400", ResponseMessage = message };
}