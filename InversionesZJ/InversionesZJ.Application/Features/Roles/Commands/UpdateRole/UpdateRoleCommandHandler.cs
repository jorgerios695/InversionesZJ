using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, GenericResponse>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<GenericResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var dto = request.RoleDto;

        if (string.IsNullOrWhiteSpace(dto.Name))
            return Fail("Role name is required");

        if (await _roleRepository.ExistsByNameExceptIdAsync(dto.Name, dto.Id))
            return Fail("Role name already exists");

        var role = await _roleRepository.GetByIdAsync(dto.Id);
        if (role is null)
            return Fail("Role not found");

        role.NameRole = dto.Name;
        role.Description = dto.Description;
        role.UpdatedAt = DateTime.UtcNow;
        role.UpdatedBy = "System";

        await _roleRepository.UpdateAsync(role, cancellationToken);

        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Role updated successfully" };
    }

    private GenericResponse Fail(string message) => new() { Success = false, ResponseCode = "400", ResponseMessage = message };
}