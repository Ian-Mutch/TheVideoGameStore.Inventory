using Microsoft.Extensions.DependencyInjection;

namespace TheVideoGameStore.Inventory.Domain.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
