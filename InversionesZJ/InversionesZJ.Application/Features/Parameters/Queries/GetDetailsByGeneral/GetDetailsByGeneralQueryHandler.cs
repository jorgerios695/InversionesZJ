using InversionesZJ.Application.DTO.Parameters;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Queries.GetDetailsByGeneral;

public class GetDetailsByGeneralQueryHandler : IRequestHandler<GetDetailsByGeneralQuery, List<DetailParameterDto>>
{
    private readonly IDetailParameterRepository _repo;
    public GetDetailsByGeneralQueryHandler(IDetailParameterRepository repo) => _repo = repo;

    public async Task<List<DetailParameterDto>> Handle(GetDetailsByGeneralQuery request, CancellationToken ct)
    {
        var items = await _repo.GetByGeneralParameterIdAsync(request.GeneralParameterId);
        return items.Select(x => new DetailParameterDto
        {
            Id = x.Id,
            GeneralParameterId = x.GeneralParameterId,
            Code = x.Code,
            Value = x.Value,
            Order = x.Order,
            IsActive = x.IsActive
        }).ToList();
    }
}