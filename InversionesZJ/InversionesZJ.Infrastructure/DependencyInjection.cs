using InversionesZJ.Application.Common;
using InversionesZJ.Application.Interfaces;
using InversionesZJ.Domain.Interfaces.common;
using InversionesZJ.Domain.Interfaces.Security;
using InversionesZJ.Infrastructure.Data;
using InversionesZJ.Infrastructure.Data.Configurations;
using InversionesZJ.Infrastructure.Repositories.Common;
using InversionesZJ.Infrastructure.Repositories.Security;
using InversionesZJ.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InversionesZJ.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Configuraciones (settings)
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        // Repositorios
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        // Servicios de infraestructura
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}