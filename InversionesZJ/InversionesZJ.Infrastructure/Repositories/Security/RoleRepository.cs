using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.Security;
using InversionesZJ.Infrastructure.Data.Configurations;
using InversionesZJ.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace InversionesZJ.Infrastructure.Repositories.Security;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Role>> GetActiveRolesAsync()
    {
        return await _dbSet
            .Where(x => x.IsActive)
            .ToListAsync();
    }
}