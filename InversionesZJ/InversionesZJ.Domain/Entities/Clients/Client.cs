using InversionesZJ.Domain.Entities.Common;
using InversionesZJ.Domain.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities.Clients;

public class Client : BaseEntity

{
    // propiedades Unicas
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DocumentNumber {  get; set; }  = string.Empty;
    public int PhoneNumber  {  get; set; }
    public string Email { get; set; } = string.Empty; 
    public string Address {  get; set; } = string.Empty;

    //navegacion 
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
