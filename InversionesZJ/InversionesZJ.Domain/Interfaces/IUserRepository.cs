using InversionesZJ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> UpdateAsync (User user, CancellationToken ct);
}
