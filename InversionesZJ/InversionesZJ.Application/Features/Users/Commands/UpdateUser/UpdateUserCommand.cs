using InversionesZJ.Application.DTO.Users;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<GenericResponse>
{
    public UpdateUserDto UserDto { get; set; } = new();
}