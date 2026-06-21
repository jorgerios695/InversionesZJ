

namespace InversionesZJ.Application.DTO.Users;

public class UpdateUserDto
{
    public long Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public long RoleId { get; set; }
}
