using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Core.Contracts.Infrastructure.Identity;
using SmartPOS.Infrastructure.Identity.Services;

namespace SmartPOS.Infrastructure.Identity;

public static class IdentityDependencies
{
    public static IServiceCollection AddIdentityDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
