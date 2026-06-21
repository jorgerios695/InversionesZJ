using InversionesZJ.Application.DTO.Users;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDetailDto?>
{
    public long Id { get; set; }
}