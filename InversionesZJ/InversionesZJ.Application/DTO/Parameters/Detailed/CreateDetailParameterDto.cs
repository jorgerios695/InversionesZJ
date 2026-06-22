namespace InversionesZJ.Application.DTO.Parameters;

public class CreateDetailParameterDto
{
    public long GeneralParameterId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public int Order { get; set; }
}