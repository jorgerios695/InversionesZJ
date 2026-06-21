using InversionesZJ.Application.DTO.Users;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<GenericResponse>
{
    public CreateUserDto UserDto { get; set; } = new();
}