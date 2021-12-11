using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public class ProductType : Enumeration
{
    public static readonly ProductType Console = new(1, nameof(Console));
    public static readonly ProductType VideoGame = new(2, nameof(VideoGame));
    public static readonly ProductType Accessory = new(3, nameof(Accessory));

    private ProductType(int id, string name)
        : base(id, name)
    {
    }
}