using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.UpdateDetailParameter;

public class UpdateDetailParameterCommandHandler : IRequestHandler<UpdateDetailParameterCommand, GenericResponse>
{
    private readonly IDetailParameterRepository _repo;
    public UpdateDetailParameterCommandHandler(IDetailParameterRepository repo) => _repo = repo;

    public async Task<GenericResponse> Handle(UpdateDetailParameterCommand request, CancellationToken ct)
    {
        var dto = request.Dto;

        if (string.IsNullOrWhiteSpace(dto.Value))
            return Fail("Value is required");

        var entity = await _repo.GetByIdAsync(dto.Id, ct);
        if (entity is null)
            return Fail("Detail not found");

        entity.Code = dto.Code;
        entity.Value = dto.Value;
        entity.Order = dto.Order;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = "System";

        await _repo.UpdateAsync(entity, ct);
        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Detail updated successfully" };
    }

    private GenericResponse Fail(string m) => new() { Success = false, ResponseCode = "400", ResponseMessage = m };
}