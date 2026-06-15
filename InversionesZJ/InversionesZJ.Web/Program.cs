using InversionesZJ.Application.Common;
using InversionesZJ.Application.Interfaces;
using InversionesZJ.Domain.Interfaces.common;
using InversionesZJ.Domain.Interfaces.Security;
using InversionesZJ.Infrastructure.Data;
using InversionesZJ.Infrastructure.Data.Configurations;
using InversionesZJ.Infrastructure.Repositories.Common;
using InversionesZJ.Infrastructure.Repositories.Security;
using InversionesZJ.Infrastructure.Services;
using InversionesZJ.Web.Components;
using InversionesZJ.Web.Services;
using InversionesZJ.Web.Services.Notifications;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//
// Blazor
//
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//
// Base de datos (EF Core + SQL Server)
//
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//
// MediatR (registra todos los Handlers de la capa Application)
//
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(InversionesZJ.Application.Features.Auth.Commands.Login.LoginCommandHandler).Assembly));

//
// Configuraciones (mapean secciones de appsettings/secrets)
//
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<NotificationService>();

//
// Autenticación por COOKIES (estándar para Blazor Server)
//
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";              
        options.AccessDeniedPath = "/login";      
        options.ExpireTimeSpan = TimeSpan.FromHours(8); 
        options.SlidingExpiration = true;         
        options.Cookie.HttpOnly = true;           
        options.Cookie.Name = "InversionesZJ.Auth";
    });

builder.Services.AddAuthorization();

// Permite que toda la app conozca el estado de autenticación
builder.Services.AddCascadingAuthenticationState();

//
// Repositorios
//
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

//
// Servicios de infraestructura
//
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IJwtService, JwtService>(); // Reservado para futura API

//
// Servicios de la capa Web
//
builder.Services.AddScoped<AuthService>();

// Acceso al HttpContext (necesario para firmar/cerrar la sesión por cookie)
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

//
// Pipeline HTTP
//
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();   // Lee la cookie y arma el usuario
app.UseAuthorization();    // Aplica las reglas de acceso

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();