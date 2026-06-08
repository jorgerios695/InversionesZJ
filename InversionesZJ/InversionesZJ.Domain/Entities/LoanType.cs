using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities;

public class LoanType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal DefaultDailyRate { get; set; }
    public string DefaultDays {  get; set; }

    // Navigation 
    public ICollection<Loan> loans { get; set; } = new List<Loan>();

}
