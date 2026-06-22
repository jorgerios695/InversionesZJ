using InversionesZJ.Application.DTO.Parameters.General;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Queries.GetGeneralParameters;

public class GetGeneralParametersQueryHandler : IRequestHandler<GetGeneralParametersQuery, List<GeneralParameterDto>>
{
    private readonly IGeneralParameterRepository _repo;
    public GetGeneralParametersQueryHandler(IGeneralParameterRepository repo) => _repo = repo;

    public async Task<List<GeneralParameterDto>> Handle(GetGeneralParametersQuery request, CancellationToken ct)
    {
        var items = await _repo.GetAllAsync();
        return items.Select(x => new GeneralParameterDto
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            Description = x.Description,
            IsActive = x.IsActive
        }).ToList();
    }
}