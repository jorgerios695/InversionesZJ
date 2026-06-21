using InversionesZJ.Application.DTO.Users;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<List<UserListDto>>
{
}