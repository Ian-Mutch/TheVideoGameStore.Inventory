namespace TheVideoGameStore.Inventory.Data.InMemory.SeedData;

static class ProductSeedData
{
    public static Product[] GetData() =>
        new Product[]
        {
            new()
            {
                ProductId = 1,
                ProductDefinitionId = 1,
                ProductTypeId = 2,
                PlatformId = 3,
                ReleaseDate = new DateTime(2020, 04, 10)
            },
            new()
            {
                ProductId = 2,
                ProductDefinitionId = 2,
                ProductTypeId = 2,
                PlatformId = 3,
                ReleaseDate = new DateTime(2016, 11, 29)
            },
            new()
            {
                ProductId = 3,
                ProductDefinitionId = 3,
                ProductTypeId = 2,
                PlatformId = 2,
                ReleaseDate = new DateTime(2022, 02, 25)
            },
            new()
            {
                ProductId = 4,
                ProductDefinitionId = 3,
                ProductTypeId = 2,
                PlatformId = 3,
                ReleaseDate = new DateTime(2022, 02, 25)
            },
            new()
            {
                ProductId = 5,
                ProductDefinitionId = 3,
                ProductTypeId = 2,
                PlatformId = 4,
                ReleaseDate = new DateTime(2022, 02, 25)
            }
    };
}
