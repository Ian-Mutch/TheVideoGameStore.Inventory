using Microsoft.EntityFrameworkCore;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Task<IEnumerable<Product>> GetAllAsync(string platform = null, string productType = null, CancellationToken cancellationToken = default)
    {
        var result = (from p in _products.AsQueryable()
                                        .Include(p => p.Stock)
                      where platform == null || p.Platform.Name == platform
                      where productType == null || p.ProductType.Name == productType
                      select p).ToList();
        return Task.FromResult<IEnumerable<Product>>(result);
    }
    public Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = (from p in _products.AsQueryable()
                      where p.Guid == id
                      select p).SingleOrDefault();
        return Task.FromResult(result);
    }

    public Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        product.Guid = Guid.NewGuid();
        _products.Add(product);
        return Task.FromResult(product);
    }

    public Task UpdateAsync(Guid id, Product product, CancellationToken cancellationToken = default)
    {
        var existingProduct = _products.Single(x => x.Guid == id);
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.PlatformId = product.PlatformId;
        existingProduct.ProductTypeId = product.ProductTypeId;

        return Task.CompletedTask;
    }
}
