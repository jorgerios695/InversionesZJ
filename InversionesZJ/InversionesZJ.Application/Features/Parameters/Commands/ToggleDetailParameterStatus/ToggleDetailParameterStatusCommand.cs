using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.ToggleDetailParameterStatus;

public class ToggleDetailParameterStatusCommand : IRequest<GenericResponse>
{
    public long Id { get; set; }
}