using InversionesZJ.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities.Security;

public class User : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int FailedAttempts { get; set; } = 0;
    public DateTime? LockedUntil {  get; set; }

    // Navigeiton 
    public ICollection<UserRole> userRoles { get; set; } = new List<UserRole>();



}
