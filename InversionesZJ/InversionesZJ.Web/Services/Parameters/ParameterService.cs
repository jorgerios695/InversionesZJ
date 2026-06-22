using InversionesZJ.Application.DTO.Parameters;
using InversionesZJ.Application.DTO.Parameters.General;
using InversionesZJ.Application.Features.Parameters.Commands.CreateDetailParameter;
using InversionesZJ.Application.Features.Parameters.Commands.CreateGeneralParameter;
using InversionesZJ.Application.Features.Parameters.Commands.ToggleDetailParameterStatus;
using InversionesZJ.Application.Features.Parameters.Commands.ToggleGeneralParameterStatus;
using InversionesZJ.Application.Features.Parameters.Commands.UpdateDetailParameter;
using InversionesZJ.Application.Features.Parameters.Commands.UpdateGeneralParameter;
using InversionesZJ.Application.Features.Parameters.Queries.GetDetailsByGeneral;
using InversionesZJ.Application.Features.Parameters.Queries.GetGeneralParameterById;
using InversionesZJ.Application.Features.Parameters.Queries.GetGeneralParameters;
using InversionesZJ.Domain.Common;
using MediatR;

namespace InversionesZJ.Web.Services.Parameters;

public class ParameterService
{
    private readonly IMediator _mediator;

    public ParameterService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<GeneralParameterDto>> GetGeneralParametersAsync()
        => await _mediator.Send(new GetGeneralParametersQuery());

    public async Task<GeneralParameterDto?> GetGeneralParameterByIdAsync(long id)
        => await _mediator.Send(new GetGeneralParameterByIdQuery { Id = id });

    public async Task<GenericResponse> CreateGeneralParameterAsync(CreateGeneralParameterDto dto)
        => await _mediator.Send(new CreateGeneralParameterCommand { Dto = dto });

    public async Task<GenericResponse> UpdateGeneralParameterAsync(UpdateGeneralParameterDto dto)
        => await _mediator.Send(new UpdateGeneralParameterCommand { Dto = dto });

    public async Task<GenericResponse> ToggleGeneralParameterStatusAsync(long id)
        => await _mediator.Send(new ToggleGeneralParameterStatusCommand { Id = id });

    // Detallados 
    public async Task<List<DetailParameterDto>> GetDetailsByGeneralAsync(long generalId)
    => await _mediator.Send(new GetDetailsByGeneralQuery { GeneralParameterId = generalId });

    public async Task<GenericResponse> CreateDetailAsync(CreateDetailParameterDto dto)
        => await _mediator.Send(new CreateDetailParameterCommand { Dto = dto });

    public async Task<GenericResponse> UpdateDetailAsync(UpdateDetailParameterDto dto)
        => await _mediator.Send(new UpdateDetailParameterCommand { Dto = dto });

    public async Task<GenericResponse> ToggleDetailStatusAsync(long id)
        => await _mediator.Send(new ToggleDetailParameterStatusCommand { Id = id });

}