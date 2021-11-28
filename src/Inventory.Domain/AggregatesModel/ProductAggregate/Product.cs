using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public class Product : Entity
{
    public Guid Guid { get; set; }
    public ProductType ProductType { get; set; }
    public Platform Platform { get; set; }
    public int ProductDefinitionId { get; set; }
    public DateTime? ReleaseDate { get; set; }

    public ProductDefinition ProductDefinition { get; set; }
}
