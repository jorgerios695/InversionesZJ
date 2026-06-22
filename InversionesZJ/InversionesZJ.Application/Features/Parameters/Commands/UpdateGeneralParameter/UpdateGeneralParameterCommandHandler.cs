using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.UpdateGeneralParameter;

public class UpdateGeneralParameterCommandHandler : IRequestHandler<UpdateGeneralParameterCommand, GenericResponse>
{
    private readonly IGeneralParameterRepository _repo;
    public UpdateGeneralParameterCommandHandler(IGeneralParameterRepository repo) => _repo = repo;

    public async Task<GenericResponse> Handle(UpdateGeneralParameterCommand request, CancellationToken ct)
    {
        var dto = request.Dto;

        if (string.IsNullOrWhiteSpace(dto.Name))
            return Fail("Name is required");
        if (await _repo.ExistsByCodeExceptIdAsync(dto.Code, dto.Id))
            return Fail("Code already exists");

        var entity = await _repo.GetByIdAsync(dto.Id, ct);
        if (entity is null)
            return Fail("Parameter not found");

        entity.Code = dto.Code;
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = "System";

        await _repo.UpdateAsync(entity, ct);
        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Parameter updated successfully" };
    }

    private GenericResponse Fail(string m) => new() { Success = false, ResponseCode = "400", ResponseMessage = m };
}