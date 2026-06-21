using BC = BCrypt.Net.BCrypt;
using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.Security;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, GenericResponse>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GenericResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.UserDto;

        // Validaciones
        var error = await Validate(dto);
        if (!string.IsNullOrEmpty(error))
            return new GenericResponse
            {
                Success = false,
                ResponseCode = "400",
                ResponseMessage = error
            };

        // Crear el usuario con la contraseña hasheada
        var user = new User
        {
            FullName = dto.FullName,
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = BC.HashPassword(dto.Password),
            FailedAttempts = 0,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        await _userRepository.CreateWithRoleAsync(user, dto.RoleId);

        return new GenericResponse
        {
            Success = true,
            ResponseCode = "200",
            ResponseMessage = "User created successfully"
        };
    }

    private async Task<string> Validate(DTO.Users.CreateUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FullName))
            return "Full name is required";

        if (string.IsNullOrWhiteSpace(dto.Username))
            return "Username is required";

        if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 6)
            return "Password must be at least 6 characters";

        if (dto.RoleId <= 0)
            return "A role must be selected";

        if (string.IsNullOrWhiteSpace(dto.Email))
            return "Email is required";

        if (await _userRepository.ExistsByUsernameAsync(dto.Username))
            return "Username already exists";

        if (await _userRepository.ExistsByEmailAsync(dto.Email))
            return "Email already exists";

        return string.Empty;
    }
}