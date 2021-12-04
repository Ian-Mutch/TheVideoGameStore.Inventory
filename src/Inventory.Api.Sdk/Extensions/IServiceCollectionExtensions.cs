using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace TheVideoGameStore.Inventory.Api.Sdk.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInventoryHttpClient(this IServiceCollection services) =>
        services.AddInventoryHttpClient(null);

    public static IServiceCollection AddInventoryHttpClient(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.AddHttpClient<IProductsHttpClient, ProductsHttpClient>(client => configureClient?.Invoke(client));
        return services;
    }
}