using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using TheVideoGameStore.Inventory.Data.InMemory.SeedData;

namespace TheVideoGameStore.Inventory.Data.InMemory.Configurations;

class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.ProductId);

        builder.Property(e => e.Guid)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<GuidValueGenerator>();

        builder.HasOne(e => e.ProductDefinition)
            .WithMany()
            .HasForeignKey(e => e.ProductDefinitionId);

        builder.HasOne(e => e.ProductType)
            .WithMany()
            .HasForeignKey(e => e.ProductTypeId);

        builder.HasOne(e => e.Platform)
            .WithMany()
            .HasForeignKey(e => e.PlatformId);

        builder.HasData(ProductSeedData.GetData());
    }
}
