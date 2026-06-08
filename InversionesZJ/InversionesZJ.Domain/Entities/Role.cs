using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Entities;

public class Role: BaseEntity
{
    public string NameRole { get; set; } = string.Empty;  
    public string Description {  get; set; } = string.Empty;


    // Navegation 
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();


}
