using Microsoft.Extensions.DependencyInjection;
using TheVideoGameStore.Inventory.Repositories.Abstractions;

namespace TheVideoGameStore.Inventory.Repositories;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(IServiceCollectionExtensions))
                .AddScoped<IProductRepository, ProductRepository>();
}
