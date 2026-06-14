using InversionesZJ.Domain.Entities.Common;

namespace InversionesZJ.Domain.Entities.Security;

public class PasswordResetToken : BaseEntity
{
    public long UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public bool IsUsed {  get; set; } = false;

    // Navigation
    public User User { get; set; } = null!;
}
