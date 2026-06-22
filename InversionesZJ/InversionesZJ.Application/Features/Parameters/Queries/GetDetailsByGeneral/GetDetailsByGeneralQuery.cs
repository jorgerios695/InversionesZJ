using InversionesZJ.Application.DTO.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Queries.GetDetailsByGeneral;

public class GetDetailsByGeneralQuery : IRequest<List<DetailParameterDto>>
{
    public long GeneralParameterId { get; set; }
}