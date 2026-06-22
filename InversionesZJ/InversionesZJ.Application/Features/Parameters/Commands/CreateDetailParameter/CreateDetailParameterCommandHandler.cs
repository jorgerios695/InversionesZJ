using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Entities.Parameters;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.CreateDetailParameter;

public class CreateDetailParameterCommandHandler : IRequestHandler<CreateDetailParameterCommand, GenericResponse>
{
    private readonly IDetailParameterRepository _repo;
    public CreateDetailParameterCommandHandler(IDetailParameterRepository repo) => _repo = repo;

    public async Task<GenericResponse> Handle(CreateDetailParameterCommand request, CancellationToken ct)
    {
        var dto = request.Dto;

        if (string.IsNullOrWhiteSpace(dto.Value))
            return Fail("Value is required");
        if (dto.GeneralParameterId <= 0)
            return Fail("Invalid category");

        var entity = new DetailParameter
        {
            GeneralParameterId = dto.GeneralParameterId,
            Code = dto.Code,
            Value = dto.Value,
            Order = dto.Order,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        await _repo.AddAsync(entity, ct);
        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Detail created successfully" };
    }

    private GenericResponse Fail(string m) => new() { Success = false, ResponseCode = "400", ResponseMessage = m };
}