namespace TheVideoGameStore.Inventory.Data.InMemory.SeedData;

static class ProductTypeSeedData
{
    public static ProductType[] GetData() =>
        new ProductType[]
        {
            new() { ProductTypeId = 1, Identifier = "Console" },
            new() { ProductTypeId = 2, Identifier = "VideoGame" },
            new() { ProductTypeId = 3, Identifier = "Accessory" }
        };
}
