using InversionesZJ.Application.DTO.Parameters.General;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Queries.GetGeneralParameters;

public class GetGeneralParametersQuery : IRequest<List<GeneralParameterDto>> 
{ 
}