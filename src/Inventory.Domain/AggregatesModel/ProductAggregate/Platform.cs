using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public class Platform : Enumeration
{
    public static Platform XboxOne = new(1, nameof(XboxOne));
    public static Platform XboxSeriesX = new(2, nameof(XboxSeriesX));
    public static Platform Playstation4 = new(3, nameof(Playstation4));
    public static Platform Playstation5 = new(4, nameof(Playstation5));
    public static Platform NintendoSwitch = new(5, nameof(NintendoSwitch));
    public static Platform PC = new(6, nameof(PC));

    public Platform(int id, string name)
        : base(id, name)
    {
    }
}