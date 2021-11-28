using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public class ProductType : Enumeration
{
    public static ProductType Console = new(1, nameof(Console));
    public static ProductType VideoGame = new(2, nameof(VideoGame));
    public static ProductType Accessory = new(3, nameof(Accessory));

    public ProductType(int id, string name)
        : base(id, name)
    {
    }
}