using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Enums.Login;

public enum ResetPasswordError
{
    None = 0,
    NotFound = 1,
    Expired = 2,
    AlreadyUsed = 3
}
