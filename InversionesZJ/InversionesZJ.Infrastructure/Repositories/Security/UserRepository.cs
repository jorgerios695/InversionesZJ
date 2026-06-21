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

    public async Task AddPasswordResetTokenAsync(PasswordResetToken token)
    {
        await _context.PasswordResetTokens.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        return await _dbSet.AnyAsync(x => x.Username == username);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _dbSet.AnyAsync(x => x.Email == email);
    }

    public async Task CreateWithRoleAsync(User user, int roleId)
    {
        await _dbSet.AddAsync(user);
        await _context.SaveChangesAsync(); // guarda para obtener el Id del usuario

        var userRole = new UserRole
        {
            UserId = user.Id,
            RoleId = roleId,
            AssignedAt = DateTime.UtcNow,
            AsignedBy = "System"
        };

        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync();
    }

    public  async Task<List<User>> GetAllWithRolesAsync()
    {
        return await _dbSet
            .Include(x => x.userRoles)
                .ThenInclude( x => x.Role)
            .ToListAsync();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbSet
            .Include(x => x.userRoles)
                .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Username == username && x.IsActive);
    }

    public async Task<PasswordResetToken?> GetPasswordResetTokenAsync(string token)
    {
        return await _context.PasswordResetTokens
        .Include(x => x.User)
        .FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task UpdatePasswordResetTokenAsync(PasswordResetToken token)
    {
        _context.PasswordResetTokens.Update(token);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdWithRoleAsync(long id)
    {
        return await _dbSet
       .Include(x => x.userRoles)
           .ThenInclude(x => x.Role)
       .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByUsernameExceptIdAsync(string username, long id)
    {
        return await _dbSet.AnyAsync(x => x.Username == username && x.Id != id);
    }

    public async Task UpdateWithRoleAsync(User user, long roleId)
    {
        _dbSet.Update(user);

        // Buscar el rol actual del usuario
        var currentRole = await _context.UserRoles
            .FirstOrDefaultAsync(x => x.UserId == user.Id);

        if (currentRole != null && currentRole.RoleId != roleId)
        {
            // El rol cambió: quitar el anterior y poner el nuevo
            _context.UserRoles.Remove(currentRole);
            _context.UserRoles.Add(new UserRole
            {
                UserId = user.Id,
                RoleId = roleId,
                AssignedAt = DateTime.UtcNow,
                AsignedBy = "System"
            });
        }

        await _context.SaveChangesAsync();

    }

    public async Task ToggleStatusAsync(long id)
    {
        var user = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (user is null) return;

        user.IsActive = !user.IsActive;
        user.UpdatedAt = DateTime.UtcNow;
        user.UpdatedBy = "System";

        await _context.SaveChangesAsync();
    }
}