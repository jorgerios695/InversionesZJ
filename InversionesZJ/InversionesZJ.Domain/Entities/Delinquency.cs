using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities;

public class Delinquency : BaseEntity

{
    public int DaysOverdue { get; set; }
    public decimal PenaltyAmount { get; set; }
    public DateTime CalculatedAt { get; set; }
    public bool IsResolved { get; set; } = false;

    // Foreign Key
    public long LoanId { get; set; }

    // Navigation
    public Loan Loan { get; set; } = null!;
}
