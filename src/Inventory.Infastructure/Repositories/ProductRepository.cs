using Microsoft.EntityFrameworkCore;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Infastructure.Repositories;

class ProductRepository : IProductRepository
{
    private readonly InventoryContext _dbContext;

    public ProductRepository(InventoryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Product>> GetAllAsync(string platform = null, string productType = null, CancellationToken cancellationToken = default) =>
        (from p in _dbContext.Products.AsNoTracking()
                                    .Include(p => p.ProductType)
                                    .Include(p => p.Platform)
         where platform == null || p.Platform.Name == platform
         where productType == null || p.ProductType.Name == productType
         select p).ToListAsync(cancellationToken: cancellationToken);

    public Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        (from p in _dbContext.Products.AsNoTracking()
                                    .Include(p => p.ProductType)
                                    .Include(p => p.Platform)
         where p.Guid == id
         select p).SingleOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        var result = _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return result.Entity;
    }

}
