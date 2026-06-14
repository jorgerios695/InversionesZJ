using InversionesZJ.Domain.Entities.Common;
using InversionesZJ.Domain.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities.Clients;

public class Responsible : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public string Email { get; set; } = string.Empty;

    // Navigation
    public ICollection<Loan> loans { get; set; } = new List<Loan>();
}
