namespace InversionesZJ.Web.Services.Loading;

public class LoadingService
{
    public event Action? OnChange;

    public bool IsLoading { get; private set; }

    public void Show()
    {
        IsLoading = true;
        OnChange?.Invoke();
    }

    public void Hide()
    {
        IsLoading = false;
        OnChange?.Invoke();
    }

    // Tiempo mínimo (ms) que el overlay permanece visible, para que no "parpadee"
    // cuando la acción es muy rápida. Cambia este número si lo quieres más largo.
    public const int DefaultMinDurationMs = 800;

    // Ejecuta una acción mostrando el overlay y garantizando un tiempo mínimo visible.
    // Uso: await LoadingService.RunAsync(async () => datos = await Servicio.GetAsync());
    public async Task RunAsync(Func<Task> action, int minDurationMs = DefaultMinDurationMs)
    {
        Show();
        try
        {
            // Espera lo que tarde la acción O el mínimo, lo que sea mayor.
            await Task.WhenAll(action(), Task.Delay(minDurationMs));
        }
        finally
        {
            Hide();
        }
    }
}