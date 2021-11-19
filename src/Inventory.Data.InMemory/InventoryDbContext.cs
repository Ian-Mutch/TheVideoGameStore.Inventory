using Microsoft.EntityFrameworkCore;
using TheVideoGameStore.Inventory.Data.Abstractions;

namespace TheVideoGameStore.Inventory.Data.InMemory;

class InventoryDbContext : DbContext, IInventoryDbContext
{
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<ProductDefinition> ProductDefinitions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Inventory");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);
    }
}
