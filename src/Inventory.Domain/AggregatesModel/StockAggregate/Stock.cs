using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

public class Stock : Entity
{
    public Guid Guid { get; set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public int ConditionId { get; private set; }
    public Condition Condition { get; private set; }
    public int Quantity { get; private set; }

    protected Stock()
    {

    }

    public Stock(Product product, Condition condition, int quantity = 0)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        if (condition is null)
            throw new ArgumentNullException(nameof(condition));

        ProductId = product.Id;
        Product = product;
        ConditionId = condition.Id;
        Condition = condition;

        SetQuantity(quantity);
    }

    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be below zero");

        Quantity = quantity;
    }
}