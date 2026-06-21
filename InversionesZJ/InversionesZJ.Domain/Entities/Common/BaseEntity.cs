using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities.Common;

public class BaseEntity
{ 
    public  long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;

}
