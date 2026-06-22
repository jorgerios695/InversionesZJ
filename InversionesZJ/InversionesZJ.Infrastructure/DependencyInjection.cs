using InversionesZJ.Application.Common;
using InversionesZJ.Application.Interfaces;
using InversionesZJ.Domain.Interfaces.common;
using InversionesZJ.Domain.Interfaces.Parameters;
using InversionesZJ.Domain.Interfaces.Roles;
using InversionesZJ.Infrastructure.Data.Configurations;
using InversionesZJ.Infrastructure.Repositories.Common;
using InversionesZJ.Infrastructure.Repositories.Parameters;
using InversionesZJ.Infrastructure.Repositories.Roles;
using InversionesZJ.Infrastructure.Repositories.Users;
using InversionesZJ.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddScoped<IGeneralParameterRepository, GeneralParameterRepository>();
        services.AddScoped<IDetailParameterRepository, DetailParameterRepository>();

        // Servicios de infraestructura
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}