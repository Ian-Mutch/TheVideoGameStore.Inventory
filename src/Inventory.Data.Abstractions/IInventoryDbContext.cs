using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TheVideoGameStore.Inventory.Data.Models;

namespace TheVideoGameStore.Inventory.Data.Abstractions;

public interface IInventoryDbContext
{
    DbSet<Platform> Platforms { get; set; }
    DbSet<ProductDefinition> ProductDefinitions { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<ProductType> ProductTypes { get; set; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
