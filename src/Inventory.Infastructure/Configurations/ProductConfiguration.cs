using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Infastructure.Configurations;

class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.HasKey(e => e.Id);

        builder.Ignore(e => e.DomainEvents);

        builder.Property(e => e.Id)
            .UseIdentityColumn();

        builder.Property(e => e.Guid)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<GuidValueGenerator>();

        builder.Property(e => e.Name)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(e => e.Description)
               .HasMaxLength(255);

        builder.HasOne(p => p.ProductType)
            .WithMany()
            .HasForeignKey(e => e.ProductTypeId);

        builder.HasOne(p => p.Platform)
            .WithMany()
            .HasForeignKey(e => e.PlatformId);
    }
}
