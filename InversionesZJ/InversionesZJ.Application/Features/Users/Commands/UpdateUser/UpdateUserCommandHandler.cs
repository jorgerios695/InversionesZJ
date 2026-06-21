using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GenericResponse>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GenericResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.UserDto;

        // Validaciones
        if (string.IsNullOrWhiteSpace(dto.FullName))
            return Fail("Full name is required");

        if (dto.RoleId <= 0)
            return Fail("A role must be selected");

        // Traer el usuario existente
        var user = await _userRepository.GetByIdWithRoleAsync(dto.Id);
        if (user is null)
            return Fail("User not found");

        // Actualizar solo los campos editables
        user.FullName = dto.FullName;
        user.Email = dto.Email;
        user.UpdatedAt = DateTime.UtcNow;
        user.UpdatedBy = "System";

        await _userRepository.UpdateWithRoleAsync(user, dto.RoleId);

        return new GenericResponse
        {
            Success = true,
            ResponseCode = "200",
            ResponseMessage = "User updated successfully"
        };
    }

    private GenericResponse Fail(string message) => new GenericResponse
    {
        Success = false,
        ResponseCode = "400",
        ResponseMessage = message
    };
}