using System.Threading;
using System.Threading.Tasks;
using TheVideoGameStore.Inventory.Data.Abstractions;

namespace TheVideoGameStore.Inventory.Data.InMemory.SeedData.Extensions;

public static class IInventoryDbContextExtensions
{
    public static void SeedData(this IInventoryDbContext dbContext)
    {
        AddSeedData(dbContext);
        dbContext.SaveChanges();
    }

    public static async Task SeedDataAsync(this IInventoryDbContext dbContext, CancellationToken cancellationToken = default)
    {
        AddSeedData(dbContext);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    private static void AddSeedData(IInventoryDbContext dbContext)
    {
        dbContext.Platforms.AddRange(PlatformSeedData.GetData());
        dbContext.ProductTypes.AddRange(ProductTypeSeedData.GetData());
        dbContext.Products.AddRange(ProductSeedData.GetData());
        dbContext.ProductDefinitions.AddRange(ProductDefinitionSeedData.GetData());
    }
}
