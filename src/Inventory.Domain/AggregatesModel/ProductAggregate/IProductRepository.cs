namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

public interface IProductRepository : IRepository
{
    Task<IEnumerable<Product>> GetAllAsync(string platform = null, string productType = null, CancellationToken cancellationToken = default);
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, Product product, CancellationToken cancellationToken = default);
}
