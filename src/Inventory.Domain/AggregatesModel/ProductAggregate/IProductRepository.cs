namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public interface IProductRepository : IRepository
{
    Task<List<Product>> GetAllAsync(string platform = null, string productType = null, CancellationToken cancellationToken = default);
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken = default);
}
