using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Domain.Enums.Login;

public enum LoginErrorType
{
    None = 0,
    UserNorFund  = 1,
    UserLocked = 2,
    InvalidPassword = 3,
    UserNotFound = 4,
}
