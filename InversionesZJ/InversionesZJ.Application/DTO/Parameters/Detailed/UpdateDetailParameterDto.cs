namespace InversionesZJ.Application.DTO.Parameters;

public class UpdateDetailParameterDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public int Order { get; set; }
}