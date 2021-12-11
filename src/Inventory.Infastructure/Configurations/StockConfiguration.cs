using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace TheVideoGameStore.Inventory.Infastructure.Configurations;

class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("stock");
        builder.HasKey(e => e.Id);

        builder.Ignore(e => e.DomainEvents);

        builder.Property(e => e.Id)
            .UseIdentityColumn();

        builder.Property(e => e.Guid)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<GuidValueGenerator>();

        builder.Property(e => e.Quantity)
            .IsRequired();

        builder.HasOne(e => e.Product)
            .WithMany(p => p.Stock)
            .HasForeignKey(e => e.ProductId)
            .IsRequired();

        builder.HasOne(p => p.Condition)
            .WithMany()
            .HasForeignKey(e => e.ConditionId)
            .IsRequired();
    }
}
