using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.Roles;
using InversionesZJ.Infrastructure.Data.Configurations;
using InversionesZJ.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace InversionesZJ.Infrastructure.Repositories.Roles;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _dbSet.AnyAsync(x => x.NameRole == name);
    }

    public async Task<bool> ExistsByNameExceptIdAsync(string name, long id)
    {
        return await _dbSet.AnyAsync(x => x.NameRole == name && x.Id != id);
    }


    public async Task<List<Role>> GetActiveRolesAsync()
    {
        return await _dbSet
            .Where(x => x.IsActive)
            .ToListAsync();
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task ToggleStatusAsync(long id)
    {
        var role = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (role is null) return;

        role.IsActive = !role.IsActive;
        role.UpdatedAt = DateTime.UtcNow;
        role.UpdatedBy = "System";

        await _context.SaveChangesAsync();
    }
}