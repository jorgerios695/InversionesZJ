using InversionesZJ.Application.DTO.Users;
using InversionesZJ.Application.Features.Roles.Queries.GetRoles;
using InversionesZJ.Application.Features.Users.Commands.CreateUser;
using InversionesZJ.Application.Features.Users.Commands.ToggleUserStatus;
using InversionesZJ.Application.Features.Users.Commands.UpdateUser;
using InversionesZJ.Application.Features.Users.Queries.GetUserById;
using InversionesZJ.Application.Features.Users.Queries.GetUsers;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Web.Services.Users;

public class UserService
{
    private readonly IMediator _mediator;

    public UserService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<UserListDto>> GetUsersAsync()
        => await _mediator.Send(new GetUsersQuery());

    public async Task<List<RoleListDto>> GetRolesAsync()
        => await _mediator.Send(new GetRolesQuery());

    public async Task<GenericResponse> CreateUserAsync(CreateUserDto dto)
        => await _mediator.Send(new CreateUserCommand { UserDto = dto });

    public async Task<UserDetailDto?> GetUserByIdAsync(long id)
    => await _mediator.Send(new GetUserByIdQuery { Id = id });

    public async Task<GenericResponse> UpdateUserAsync(UpdateUserDto dto)
        => await _mediator.Send(new UpdateUserCommand { UserDto = dto });

    public async Task<GenericResponse> ToggleUserStatusAsync(long id)
    => await _mediator.Send(new ToggleUserStatusCommand { Id = id });
}