using InversionesZJ.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Interfaces.common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<T>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync (T entity, CancellationToken ct = default);
    Task UpdateAsync (T entity, CancellationToken ct = default);
    Task DeleteAsync (T enity , CancellationToken ct = default);
}
