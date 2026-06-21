using InversionesZJ.Application.DTO.Users;
using InversionesZJ.Domain.Interfaces.Roles;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDetailDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdWithRoleAsync(request.Id);

        if (user is null)
            return null;

        return new UserDetailDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Username = user.Username,
            Email = user.Email,
            RoleId = user.userRoles.FirstOrDefault()?.RoleId ?? 0
        };
    }
}