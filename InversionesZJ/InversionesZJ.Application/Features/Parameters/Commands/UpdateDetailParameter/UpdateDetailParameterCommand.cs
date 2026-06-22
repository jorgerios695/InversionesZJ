using InversionesZJ.Application.DTO.Parameters;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.UpdateDetailParameter;

public class UpdateDetailParameterCommand : IRequest<GenericResponse>
{
    public UpdateDetailParameterDto Dto { get; set; } = new();
}