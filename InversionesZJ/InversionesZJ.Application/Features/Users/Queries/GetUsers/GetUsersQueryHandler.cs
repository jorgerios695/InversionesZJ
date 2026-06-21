using InversionesZJ.Application.DTO.Users;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Application.Features.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserListDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<List<UserListDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllWithRolesAsync();

        return users.Select(user => new UserListDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Username = user.Username,
            Email = user.Email,
            IsActive = user.IsActive,
            Roles = user.userRoles.Select(ur => ur.Role.NameRole).ToList()
        }).ToList();
    }
}
