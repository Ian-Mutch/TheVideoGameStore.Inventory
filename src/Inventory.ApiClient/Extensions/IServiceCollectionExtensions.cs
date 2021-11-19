using Microsoft.Extensions.DependencyInjection;
using TheVideoGameStore.Inventory.ApiClient.Contracts;

namespace TheVideoGameStore.Inventory.ApiClient.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInventoryHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<IProductsHttpClient, ProductsHttpClient>();
        return services;
    }
}