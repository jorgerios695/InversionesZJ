using InversionesZJ.Web.Services;
using Microsoft.AspNetCore.Components;

namespace InversionesZJ.Web.Components.Pages.Login;

public partial class ResetPassword
{
    [Inject] private AuthService AuthService { get; set; } = default!;

    [SupplyParameterFromQuery]
    public string? Token { get; set; }

    private string newPassword = string.Empty;
    private string confirmPassword = string.Empty;
    private string errorMessage = string.Empty;
    private string successMessage = string.Empty;
    private bool isLoading = false;
    private bool isDone = false;

    private async Task HandleReset()
    {
        errorMessage = string.Empty;
        successMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Token))
        {
            errorMessage = "Enlace inválido";
            return;
        }

        if (newPassword.Length < 6)
        {
            errorMessage = "La contraseña debe tener al menos 6 caracteres";
            return;
        }

        if (newPassword != confirmPassword)
        {
            errorMessage = "Las contraseñas no coinciden";
            return;
        }

        isLoading = true;

        try
        {
            var response = await AuthService.ResetPasswordAsync(Token, newPassword);

            if (response.Success)
            {
                successMessage = "Contraseña actualizada. Ya puedes iniciar sesión.";
                isDone = true;
            }
            else
            {
                errorMessage = response.ResponseMessage;
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
        finally
        {
            isLoading = false;
        }
    }
}
