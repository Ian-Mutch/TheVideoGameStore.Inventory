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

    public async Task<IEnumerable<Product>> GetAllAsync(string platform = null, string productType = null, CancellationToken cancellationToken = default)
    {
        var query = from p in _dbContext.Products.AsNoTracking()
                                                .Include(p => p.ProductType)
                                                .Include(p => p.Platform)
                    where platform == null || p.Platform.Name == platform
                    where productType == null || p.ProductType.Name == productType
                    select p;
        
        return await query.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = from p in _dbContext.Products.AsNoTracking()
                                                .Include(p => p.ProductType)
                                                .Include(p => p.Platform)
                    where p.Guid == id
                    select p;

        return await query.SingleOrDefaultAsync(cancellationToken: cancellationToken);
    }
        
    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        var result = _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return result.Entity;
    }

    public async Task UpdateAsync(Guid id, Product product, CancellationToken cancellationToken = default)
    {
        var existingProduct = _dbContext.Products.Single(p => p.Guid == id);
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.ProductTypeId = product.ProductTypeId;
        existingProduct.PlatformId = product.PlatformId;
        existingProduct.ReleaseDate = product.ReleaseDate;

        await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}
