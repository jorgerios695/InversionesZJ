using InversionesZJ.Application.DTO.Auth;
using InversionesZJ.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace InversionesZJ.Web.Components.Pages.Login;

public partial class Login
{
    [Inject] private AuthService AuthService { get; set; } = default!;
    [Inject] private NavigationManager Navigation { get; set; } = default!;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    [SupplyParameterFromForm]
    private LoginInputModel Input { get; set; } = new();

    private string errorMessage = string.Empty;

    protected override void OnInitialized()
    {
        // Si el usuario ya tiene cookie válida, no tiene sentido mostrar el login.
        if (HttpContext.User.Identity?.IsAuthenticated == true)
            Navigation.NavigateTo("/");
    }

    private async Task HandleLogin()
    {
        var response = await AuthService.LoginAsync(Input.Username, Input.Password);

        if (response.Success && response.ResponseObject is LoggedUserDto user)
        {
            // Estamos dentro de una petición HTTP real (POST), así que aquí
            // sí se puede escribir la cookie de autenticación.
            var principal = ClaimsBuilder.Build(user);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            Navigation.NavigateTo("/");
        }
        else
        {
            errorMessage = response.ResponseMessage;
        }
    }

    public class LoginInputModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
