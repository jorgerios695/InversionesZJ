using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Application.DTO.Users;

public class UserListDto
{
    public long Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<string> Roles { get; set; } = new();
}
