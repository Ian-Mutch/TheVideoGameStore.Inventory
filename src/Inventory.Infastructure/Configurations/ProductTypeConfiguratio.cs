using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Infastructure.Configurations;

class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {

        builder.ToTable("productType");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseIdentityColumn();

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(e => e.Name)
               .HasMaxLength(200)
               .IsRequired();

        builder.HasData(Domain.SeedWork.Enumeration.GetAll<ProductType>());
    }
}
