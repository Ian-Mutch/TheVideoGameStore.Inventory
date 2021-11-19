using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheVideoGameStore.Inventory.Data.Abstractions;
using TheVideoGameStore.Inventory.Models;
using TheVideoGameStore.Inventory.Repositories.Abstractions;

namespace TheVideoGameStore.Inventory.Repositories;

class ProductRepository : IProductRepository
{
    private readonly IInventoryDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProductRepository(IInventoryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<Product> GetAll(Platform? platform = null, ProductType? productType = null)
    {
        return from p in _dbContext.Products.AsNoTracking()
                                            .Include(p => p.ProductDefinition)
                                            .Include(p => p.ProductType)
                                            .Include(p => p.Platform)
               where platform == null || p.Platform.Name == platform.ToString()
               where productType == null || p.ProductType.Identifier == productType.ToString()
               select _mapper.Map<Product>(p);
    }
}
