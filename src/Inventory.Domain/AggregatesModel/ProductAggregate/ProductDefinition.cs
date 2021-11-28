using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public class ProductDefinition : ValueObject
{
    public string Name { get; init; }
    public string Description { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Description;
    }
}
