using InversionesZJ.Web.Services.Notifications;
using Microsoft.AspNetCore.Components;

namespace InversionesZJ.Web.Components.Shared;

public partial class NotificationContainer : IDisposable
{
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private List<NotificationMessage> notifications = new();

    protected override void OnInitialized()
    {
        NotificationService.OnNotify += HandleNotification;
    }

    private async void HandleNotification(NotificationMessage notification)
    {
        notifications.Add(notification);
        await InvokeAsync(StateHasChanged);

        // El toast desaparece solo después de 3.5 segundos
        await Task.Delay(3500);

        notifications.Remove(notification);
        await InvokeAsync(StateHasChanged);
    }

    private string GetIcon(NotificationType type) => type switch
    {
        NotificationType.Success => "✓",
        NotificationType.Error => "✕",
        NotificationType.Warning => "!",
        NotificationType.Info => "i",
        _ => ""
    };

    public void Dispose()
    {
        NotificationService.OnNotify -= HandleNotification;
    }
}
