using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace InversionesZJ.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // MediatR — registra todos los Handlers de esta capa
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}