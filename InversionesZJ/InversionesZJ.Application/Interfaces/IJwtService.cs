using InversionesZJ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user, List<string> roles);
    }
}
