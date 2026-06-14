using InversionesZJ.Domain.Entities.Clients;
using InversionesZJ.Domain.Entities.Common;
using InversionesZJ.Domain.Entities.Parameters;
using InversionesZJ.Domain.Enums.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities.Operations;
 public class Loan : BaseEntity
{
    public decimal Capital {  get; set; }
    public decimal DailyRate { get; set; }
    public int ScheduleDays { get; set; }
    public DateTime StartDatee {  get; set; }
    public DateTime DueDate {  get; set; }
    public LoanStatus Status { get; set; } = LoanStatus.Active;
    public string? Observations { get; set; }

    // foreing  Keys
    public long ClientId { get; set; }
    public long ResponsibleId { get; set; }
    public long loanTypeId { get; set; }

    // navigation 
    public Client Client { get; set; } = null!;
    public Responsible Responsible { get; set; } = null!;
    public LoanType LoanType { get; set; } = null!;
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<Delinquency> Delinquencies { get; set; } = new List<Delinquency>();


}
