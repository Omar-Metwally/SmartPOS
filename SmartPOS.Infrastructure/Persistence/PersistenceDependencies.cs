using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Core.Contracts.Infrastructure.Persistence;
using SmartPOS.Infrastructure.Persistence.Data;
using SmartPOS.Infrastructure.Persistence.Repositories;

namespace SmartPOS.Infrastructure.Persistence;

internal static class PersistenceDependencies
{
    internal static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
          b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
          .EnableSensitiveDataLogging());

        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IBranchRepository, BranchRepository>()
                .AddTransient<ISafeRepository, SafeRepository>()
                .AddTransient<ISupplierRepository, SupplierRepository>()
                .AddTransient<IPurchaseRepository, PurchaseRepository>()
                .AddTransient<IWarehouseRepository, WarehouseRepository>();

        return services;
    }
}
