using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Entities.Parameters;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.CreateGeneralParameter;

public class CreateGeneralParameterCommandHandler : IRequestHandler<CreateGeneralParameterCommand, GenericResponse>
{
    private readonly IGeneralParameterRepository _repo;
    public CreateGeneralParameterCommandHandler(IGeneralParameterRepository repo) => _repo = repo;

    public async Task<GenericResponse> Handle(CreateGeneralParameterCommand request, CancellationToken ct)
    {
        var dto = request.Dto;

        if (string.IsNullOrWhiteSpace(dto.Code))
            return Fail("Code is required");
        if (string.IsNullOrWhiteSpace(dto.Name))
            return Fail("Name is required");
        if (await _repo.ExistsByCodeAsync(dto.Code))
            return Fail("Code already exists");

        var entity = new GeneralParameter
        {
            Code = dto.Code,
            Name = dto.Name,
            Description = dto.Description,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        await _repo.AddAsync(entity, ct);
        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Parameter created successfully" };
    }

    private GenericResponse Fail(string m) => new() { Success = false, ResponseCode = "400", ResponseMessage = m };
}