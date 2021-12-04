using Microsoft.Extensions.DependencyInjection;
using TheVideoGameStore.Inventory.Domain.AggregatesModel;

namespace TheVideoGameStore.Inventory.Infastructure.Repositories.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblyOf<InventoryContext>()
                        .AddClasses(c => c.AssignableTo<IRepository>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime());

        return services;
    }
}
