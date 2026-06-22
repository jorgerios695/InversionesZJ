using InversionesZJ.Domain.Entities.Parameters;
using InversionesZJ.Domain.Interfaces.common;

namespace InversionesZJ.Domain.Interfaces.Parameters;

public interface IGeneralParameterRepository : IGenericRepository<GeneralParameter>
{
    Task<List<GeneralParameter>> GetAllAsync();
    Task<bool> ExistsByCodeAsync(string code);
    Task<bool> ExistsByCodeExceptIdAsync(string code, long id);
    Task ToggleStatusAsync(long id);
}