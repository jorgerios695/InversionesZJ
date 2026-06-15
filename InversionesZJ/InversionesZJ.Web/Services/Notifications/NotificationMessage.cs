namespace InversionesZJ.Web.Services.Notifications;

public class NotificationMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
}

public enum NotificationType
{
    Success,
    Error,
    Warning,
    Info
}