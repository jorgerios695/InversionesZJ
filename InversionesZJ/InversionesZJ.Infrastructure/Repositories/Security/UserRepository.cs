using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.Security;
using InversionesZJ.Infrastructure.Data.Configurations;
using InversionesZJ.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace InversionesZJ.Infrastructure.Repositories.Security;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbSet
            .Include(x => x.userRoles)
                .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Username == username && x.IsActive);
    }
}