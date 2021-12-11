using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public class Platform : Enumeration
{
    public static readonly Platform XboxOne = new(1, nameof(XboxOne));
    public static readonly Platform XboxSeriesX = new(2, nameof(XboxSeriesX));
    public static readonly Platform Playstation4 = new(3, nameof(Playstation4));
    public static readonly Platform Playstation5 = new(4, nameof(Playstation5));
    public static readonly Platform NintendoSwitch = new(5, nameof(NintendoSwitch));
    public static readonly Platform PC = new(6, nameof(PC));

    private Platform(int id, string name)
        : base(id, name)
    {
    }
}