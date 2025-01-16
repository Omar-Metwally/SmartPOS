using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Infrastructure.Identity;
using SmartPOS.Infrastructure.Persistence;
using SmartPOS.Infrastructure.Persistence.Data;

namespace SmartPOS.Infrastructure;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistenceDependencies(configuration)
            .AddIdentityDependencies(configuration);

        return services;
    }
}
