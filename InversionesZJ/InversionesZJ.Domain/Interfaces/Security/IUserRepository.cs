using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.common;

namespace InversionesZJ.Domain.Interfaces.Security;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddPasswordResetTokenAsync(PasswordResetToken token);
    Task<PasswordResetToken?> GetPasswordResetTokenAsync(string token);
    Task UpdatePasswordResetTokenAsync(PasswordResetToken token);
    Task<List<User>> GetAllWithRolesAsync();
    Task<bool> ExistsByUsernameAsync(string username);
    Task<bool> ExistsByEmailAsync(string email);
    Task CreateWithRoleAsync(User user, int roleId);
    Task<User?> GetByIdWithRoleAsync(long id);
    Task<bool> ExistsByUsernameExceptIdAsync(string username, long id);
    Task UpdateWithRoleAsync(User user, long roleId);
    Task ToggleStatusAsync(long id);
}