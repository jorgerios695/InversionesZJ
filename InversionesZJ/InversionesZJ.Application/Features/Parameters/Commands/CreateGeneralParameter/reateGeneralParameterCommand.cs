using InversionesZJ.Application.DTO.Parameters.General;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.CreateGeneralParameter;

public class CreateGeneralParameterCommand : IRequest<GenericResponse>
{
    public CreateGeneralParameterDto Dto { get; set; } = new();
}