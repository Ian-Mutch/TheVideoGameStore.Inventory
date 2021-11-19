using Microsoft.Extensions.DependencyInjection;
using TheVideoGameStore.Inventory.Data.Abstractions;

namespace TheVideoGameStore.Inventory.Data.InMemory.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInventoryDbInMemory(this IServiceCollection services) =>
        services.AddDbContext<IInventoryDbContext, InventoryDbContext>();
}
