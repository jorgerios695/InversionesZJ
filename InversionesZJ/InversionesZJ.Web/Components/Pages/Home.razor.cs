using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace InversionesZJ.Web.Components.Pages;

public partial class Home
{
    [Inject] private NavigationManager Navigation { get; set; } = default!;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    private async Task Logout()
    {
        // Borra la cookie de autenticación (deshace el SignInAsync del login).
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        Navigation.NavigateTo("/login");
    }
}
