using InversionesZJ.Domain.Entities.Security;
using InversionesZJ.Domain.Interfaces.common;


namespace InversionesZJ.Domain.Interfaces.Roles;

public  interface IRoleRepository : IGenericRepository<Role>
{
    Task<List<Role>> GetActiveRolesAsync();
    Task<List<Role>> GetAllRolesAsync();
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> ExistsByNameExceptIdAsync(string name, long id);
    Task ToggleStatusAsync(long id);

}
