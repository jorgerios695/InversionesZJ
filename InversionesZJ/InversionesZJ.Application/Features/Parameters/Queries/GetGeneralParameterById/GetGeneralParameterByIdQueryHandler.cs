using InversionesZJ.Application.DTO.Parameters.General;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Queries.GetGeneralParameterById;

public class GetGeneralParameterByIdQueryHandler : IRequestHandler<GetGeneralParameterByIdQuery, GeneralParameterDto?>
{
    private readonly IGeneralParameterRepository _repo;
    public GetGeneralParameterByIdQueryHandler(IGeneralParameterRepository repo) => _repo = repo;

    public async Task<GeneralParameterDto?> Handle(GetGeneralParameterByIdQuery request, CancellationToken ct)
    {
        var x = await _repo.GetByIdAsync(request.Id, ct);
        if (x is null) return null;

        return new GeneralParameterDto
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            Description = x.Description,
            IsActive = x.IsActive
        };
    }
}