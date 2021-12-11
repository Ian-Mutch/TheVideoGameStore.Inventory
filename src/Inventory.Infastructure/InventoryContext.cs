using Microsoft.EntityFrameworkCore;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace TheVideoGameStore.Inventory.Infastructure;

public class InventoryContext : DbContext
{
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<Stock> StockItems { get; set; }
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