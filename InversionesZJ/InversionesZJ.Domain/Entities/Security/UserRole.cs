using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities.Security;

// Table Intermedia 
public class UserRole
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public string AsignedBy { get; set; } = string.Empty;

    // Navigation 
    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;


}
