namespace TheVideoGameStore.Inventory.Data.InMemory.SeedData;

static class PlatformSeedData
{
    public static Platform[] GetData() =>
        new Platform[]
        {
            new() { PlatformId = 1, Name = "XboxOne" },
            new() { PlatformId = 2, Name = "XboxSeriesX" },
            new() { PlatformId = 3, Name = "Playstation4" },
            new() { PlatformId = 4, Name = "Playstation5" },
            new() { PlatformId = 5, Name = "NintendoSwitch" },
            new() { PlatformId = 6, Name = "PC" }
        };
}
