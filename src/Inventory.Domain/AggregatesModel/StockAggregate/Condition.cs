using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

public class Condition : Enumeration
{
    public static readonly Condition New = new(1, nameof(New));
    public static readonly Condition Preowned = new(2, nameof(Preowned));

    private Condition(int id, string name)
        : base(id, name)
    {
    }
}