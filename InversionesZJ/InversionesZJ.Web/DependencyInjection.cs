using InversionesZJ.Web.Services;
using InversionesZJ.Web.Services.Loading;
using InversionesZJ.Web.Services.Notifications;
using InversionesZJ.Web.Services.Roles;
using InversionesZJ.Web.Services.Users;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InversionesZJ.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection services)
    {
        // Blazor
        services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Autenticación por cookies
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/login";
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "InversionesZJ.Auth";
            });

        services.AddAuthorization();
        services.AddCascadingAuthenticationState();
        services.AddHttpContextAccessor();

        // Servicios de la capa Web
        services.AddScoped<AuthService>();
        services.AddScoped<NotificationService>();
        services.AddScoped<LoadingService>();
        services.AddScoped<UserService>();
        services.AddScoped<RoleService>();

        return services;
    }
}