using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;

internal class ProductRepository : IProductRepository
{
    public Task<List<Product>> GetAllAsync(string platform = null, string productType = null, CancellationToken cancellationToken = default)
    {
        var products = new Product[]
        {
            new()
            {
                Name = "Game 01",
                Description = "Some description of game 01",
                Platform = Platform.Playstation4,
                ProductType = ProductType.VideoGame,
                ReleaseDate = new DateTime(2021, 12, 25)
            },
            new()
            {
                Name = "Game 02",
                Description = "Some description of game 01",
                Platform = Platform.Playstation4,
                ProductType = ProductType.VideoGame,
                ReleaseDate = new DateTime(2021, 12, 25)
            },
            new()
            {
                Name = "Playstation 5 controller",
                Description = "Some description of a playstation 5 controller",
                Platform = Platform.Playstation5,
                ProductType = ProductType.Accessory,
                ReleaseDate = new DateTime(2021, 12, 25)
            },
            new()
            {
                Name = "Game 03",
                Description = "Some description of game 03",
                Platform = Platform.XboxSeriesX,
                ProductType = ProductType.VideoGame,
                ReleaseDate = new DateTime(2021, 12, 25)
            },
            new()
            {
                Name = "Playstation 4 controller",
                Description = "Some description of a playstation 4 controller",
                Platform = Platform.Playstation4,
                ProductType = ProductType.Accessory,
                ReleaseDate = new DateTime(2021, 12, 25)
            },
        };
        var result = (from p in products.AsQueryable()
                      where platform == null || p.Platform.Name == platform
                      where productType == null || p.ProductType.Name == productType
                      select p).ToList();
        return Task.FromResult(result);
    }
}
