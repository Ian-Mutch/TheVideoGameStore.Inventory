using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TheVideoGameStore.Inventory.Data.Abstractions;
using TheVideoGameStore.Inventory.Data.InMemory.SeedData.Extensions;

namespace TheVideoGameStore.Inventory.Data.InMemory.Extensions;

public static class IApplicationBuilderExtensions
{
    private static bool _dataSeeded;

    public static IApplicationBuilder UseInventoryDbInMemorySeedData(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            await SeedDataAsync(context);
            await next.Invoke();
        });
        return app;
    }

    private static async Task SeedDataAsync(HttpContext context)
    {
        if (_dataSeeded)
            return;

        var dbContext = context.RequestServices.GetService<IInventoryDbContext>();
        await dbContext.SeedDataAsync();

        _dataSeeded = true;
    }
}
