using InversionesZJ.Domain.Entities;
using InversionesZJ.Domain.Interfaces;
using InversionesZJ.Infrastructure.Data;
using InversionesZJ.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InversionesZJ.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // metodo busca el usuarrio Por nombre de usuario 
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(x => x.userRoles)
                .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Username == username && x.IsActive);// solo retornamos Usuarios Activos 
    }
    // Actualiza el usuario 
    public async Task<bool> UpdateAsync(User user, CancellationToken ct)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}