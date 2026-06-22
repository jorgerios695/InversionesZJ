using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.ToggleDetailParameterStatus;

public class ToggleDetailParameterStatusCommandHandler : IRequestHandler<ToggleDetailParameterStatusCommand, GenericResponse>
{
    private readonly IDetailParameterRepository _repo;
    public ToggleDetailParameterStatusCommandHandler(IDetailParameterRepository repo) => _repo = repo;

    public async Task<GenericResponse> Handle(ToggleDetailParameterStatusCommand request, CancellationToken ct)
    {
        await _repo.ToggleStatusAsync(request.Id);
        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Status updated successfully" };
    }
}