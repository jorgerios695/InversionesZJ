using InversionesZJ.Domain.Entities.Common;

namespace InversionesZJ.Domain.Entities.Parameters;

public class DetailParameter : BaseEntity
{
    public long GeneralParameterId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public int Order { get; set; }

    // Navigation — la categoría padre
    public GeneralParameter GeneralParameter { get; set; } = null!;
}