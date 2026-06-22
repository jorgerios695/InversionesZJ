using InversionesZJ.Domain.Entities.Parameters;
using InversionesZJ.Domain.Interfaces.common;

namespace InversionesZJ.Domain.Interfaces.Parameters;

public interface IDetailParameterRepository : IGenericRepository<DetailParameter>
{
    Task<List<DetailParameter>> GetByGeneralParameterIdAsync(long generalParameterId);
    Task ToggleStatusAsync(long id);
}