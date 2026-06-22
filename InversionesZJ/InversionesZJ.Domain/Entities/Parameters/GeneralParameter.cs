using InversionesZJ.Domain.Entities.Common;

namespace InversionesZJ.Domain.Entities.Parameters;

public class GeneralParameter : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation — los valores hijos de esta categoría
    public ICollection<DetailParameter> Details { get; set; } = new List<DetailParameter>();
}