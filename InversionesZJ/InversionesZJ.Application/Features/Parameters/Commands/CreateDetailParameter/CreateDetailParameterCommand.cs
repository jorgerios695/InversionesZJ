using InversionesZJ.Application.DTO.Parameters;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.CreateDetailParameter;

public class CreateDetailParameterCommand : IRequest<GenericResponse>
{
    public CreateDetailParameterDto Dto { get; set; } = new();
}