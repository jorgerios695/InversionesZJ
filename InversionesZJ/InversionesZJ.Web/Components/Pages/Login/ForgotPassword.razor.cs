using InversionesZJ.Web.Services;
using Microsoft.AspNetCore.Components;

namespace InversionesZJ.Web.Components.Pages.Login;

public partial class ForgotPassword
{
    [Inject] private AuthService AuthService { get; set; } = default!;

    private string username = string.Empty;
    private string message = string.Empty;
    private bool isLoading = false;

    private async Task HandleForgot()
    {
        message = string.Empty;
        isLoading = true;

        try
        {
            var response = await AuthService.ForgotPasswordAsync(username);
            message = response.ResponseMessage;
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        finally
        {
            isLoading = false;
        }
    }
}
