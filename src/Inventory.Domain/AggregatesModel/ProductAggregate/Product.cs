using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;
using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public class Product : Entity
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
    public int PlatformId { get; set; }
    public Platform Platform { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public ICollection<Stock> Stock { get; } = new List<Stock>();

    protected Product() { }

    public Product(int id)
    {
        Id = id;
    }
}
