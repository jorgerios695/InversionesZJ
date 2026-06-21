using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Users.Commands.ToggleUserStatus;

public class ToggleUserStatusCommand : IRequest<GenericResponse>
{
    public long Id { get; set; }
}