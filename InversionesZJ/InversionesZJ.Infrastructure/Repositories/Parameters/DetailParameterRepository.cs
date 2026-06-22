using InversionesZJ.Domain.Entities.Parameters;
using InversionesZJ.Domain.Interfaces.Parameters;
using InversionesZJ.Infrastructure.Data;
using InversionesZJ.Infrastructure.Data.Configurations;
using InversionesZJ.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace InversionesZJ.Infrastructure.Repositories.Parameters;

public class DetailParameterRepository : GenericRepository<DetailParameter>, IDetailParameterRepository
{
    public DetailParameterRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<DetailParameter>> GetByGeneralParameterIdAsync(long generalParameterId)
    {
        return await _dbSet
            .Where(x => x.GeneralParameterId == generalParameterId)
            .OrderBy(x => x.Order)
            .ToListAsync();
    }

    public async Task ToggleStatusAsync(long id)
    {
        var detail = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (detail is null) return;

        detail.IsActive = !detail.IsActive;
        detail.UpdatedAt = DateTime.UtcNow;
        detail.UpdatedBy = "System";

        await _context.SaveChangesAsync();
    }
}