using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheVideoGameStore.Inventory.Data.InMemory.SeedData;

namespace TheVideoGameStore.Inventory.Data.InMemory.Configurations;

class ProductDefinitionConfiguration : IEntityTypeConfiguration<ProductDefinition>
{
    public void Configure(EntityTypeBuilder<ProductDefinition> builder)
    {
        builder.HasKey(e => e.ProductDefinitionId);

        builder.Property(e => e.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(e => e.Description)
               .HasMaxLength(255);

        builder.HasData(ProductDefinitionSeedData.GetData());
    }
}