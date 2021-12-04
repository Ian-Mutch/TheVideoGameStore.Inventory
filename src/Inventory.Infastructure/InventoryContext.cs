using Microsoft.EntityFrameworkCore;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Infastructure;

public class InventoryContext : DbContext
{
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryContext).Assembly);
    }
}