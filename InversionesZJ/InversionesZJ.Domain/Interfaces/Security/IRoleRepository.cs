using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Interfaces.Security;

public  interface IRoleRepository : IGenericRepository<Role>
{
    Task<List<Role>> GetActiveRolesAsync();

}
