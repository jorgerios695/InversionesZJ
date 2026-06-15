namespace InversionesZJ.Web.Services.Notifications;

public class NotificationService
{
    // Evento que el componente visual escuchará
    public event Action<NotificationMessage>? OnNotify;

    public void ShowSuccess(string message) => Show(message, NotificationType.Success);
    public void ShowError(string message) => Show(message, NotificationType.Error);
    public void ShowWarning(string message) => Show(message, NotificationType.Warning);
    public void ShowInfo(string message) => Show(message, NotificationType.Info);

    private void Show(string message, NotificationType type)
    {
        OnNotify?.Invoke(new NotificationMessage
        {
            Message = message,
            Type = type
        });
    }
}