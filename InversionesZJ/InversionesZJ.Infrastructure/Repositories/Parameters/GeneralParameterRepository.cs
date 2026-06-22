using InversionesZJ.Domain.Entities.Parameters;
using InversionesZJ.Domain.Interfaces.Parameters;
using InversionesZJ.Infrastructure.Data;
using InversionesZJ.Infrastructure.Data.Configurations;
using InversionesZJ.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace InversionesZJ.Infrastructure.Repositories.Parameters;

public class GeneralParameterRepository : GenericRepository<GeneralParameter>, IGeneralParameterRepository
{
    public GeneralParameterRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<GeneralParameter>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<bool> ExistsByCodeAsync(string code)
        => await _dbSet.AnyAsync(x => x.Code == code);

    public async Task<bool> ExistsByCodeExceptIdAsync(string code, long id)
        => await _dbSet.AnyAsync(x => x.Code == code && x.Id != id);

    public async Task ToggleStatusAsync(long id)
    {
        var param = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (param is null) return;

        param.IsActive = !param.IsActive;
        param.UpdatedAt = DateTime.UtcNow;
        param.UpdatedBy = "System";

        await _context.SaveChangesAsync();
    }
}