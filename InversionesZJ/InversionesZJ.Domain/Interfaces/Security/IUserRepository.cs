using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.common;

namespace InversionesZJ.Domain.Interfaces.Security;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddPasswordResetTokenAsync(PasswordResetToken token);
    Task<PasswordResetToken?> GetPasswordResetTokenAsync(string token);
    Task UpdatePasswordResetTokenAsync(PasswordResetToken token);
}