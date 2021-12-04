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
}
