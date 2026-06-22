using InversionesZJ.Domain.Common;
using InversionesZJ.Domain.Interfaces.Parameters;
using MediatR;

namespace InversionesZJ.Application.Features.Parameters.Commands.ToggleGeneralParameterStatus;

public class ToggleGeneralParameterStatusCommandHandler : IRequestHandler<ToggleGeneralParameterStatusCommand, GenericResponse>
{
    private readonly IGeneralParameterRepository _repo;
    public ToggleGeneralParameterStatusCommandHandler(IGeneralParameterRepository repo) => _repo = repo;

    public async Task<GenericResponse> Handle(ToggleGeneralParameterStatusCommand request, CancellationToken ct)
    {
        await _repo.ToggleStatusAsync(request.Id);
        return new GenericResponse { Success = true, ResponseCode = "200", ResponseMessage = "Status updated successfully" };
    }
}