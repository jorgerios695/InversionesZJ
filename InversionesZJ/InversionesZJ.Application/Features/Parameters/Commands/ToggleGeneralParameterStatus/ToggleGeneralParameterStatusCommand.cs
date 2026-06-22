using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.ToggleGeneralParameterStatus;

public class ToggleGeneralParameterStatusCommand : IRequest<GenericResponse>
{
    public long Id { get; set; }
}