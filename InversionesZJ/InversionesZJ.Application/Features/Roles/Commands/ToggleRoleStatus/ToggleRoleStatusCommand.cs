using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Roles.Commands.ToggleRoleStatus;

public class ToggleRoleStatusCommand : IRequest<GenericResponse>
{
    public long Id { get; set; }
}