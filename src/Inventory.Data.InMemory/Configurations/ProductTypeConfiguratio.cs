using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheVideoGameStore.Inventory.Data.InMemory.SeedData;

namespace TheVideoGameStore.Inventory.Data.InMemory.Configurations;

class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.HasKey(e => e.ProductTypeId);

        builder.Property(e => e.Identifier)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasData(ProductTypeSeedData.GetData());
    }
}
