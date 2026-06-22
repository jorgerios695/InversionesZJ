using InversionesZJ.Application.DTO.Parameters.General;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Queries.GetGeneralParameterById;

public class GetGeneralParameterByIdQuery : IRequest<GeneralParameterDto?>
{
    public long Id { get; set; }
}