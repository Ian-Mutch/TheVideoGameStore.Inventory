namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
}
