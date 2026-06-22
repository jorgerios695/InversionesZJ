using InversionesZJ.Application.DTO.Parameters.General;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.UpdateGeneralParameter;

public class UpdateGeneralParameterCommand : IRequest<GenericResponse>
{
    public UpdateGeneralParameterDto Dto { get; set; } = new();
}