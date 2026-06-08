using InversionesZJ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities;

public class Payment
{
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
    public DateTime PaymentDate { get; set; }
   public string? Notes { get; set; }

    // Foreign Key 
    public long LoanId {  get; set; }

    // Navigation 
    public Loan Loan { get; set; } = null!;

}
