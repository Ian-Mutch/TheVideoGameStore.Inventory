using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TheVideoGameStore.Inventory.Infastructure.Repositories.Extensions;

namespace TheVideoGameStore.Inventory.Infastructure.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInfastructure(this IServiceCollection services)
    {
        services.AddDbContext<InventoryContext>((services, options) =>
        {
            var config = services.GetRequiredService<IConfiguration>();
            options.UseSqlServer(config.GetConnectionString("Inventory"),
                                    sqlServerOptionsAction: sqlOptions =>
                                    {
                                        sqlOptions.MigrationsAssembly(typeof(InventoryContext).GetTypeInfo().Assembly.GetName().Name);
                                        //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                    });
        });
        services.AddRepositories();
        return services;
    }
}
