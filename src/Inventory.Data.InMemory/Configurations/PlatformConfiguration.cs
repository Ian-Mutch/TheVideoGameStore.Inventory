using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheVideoGameStore.Inventory.Data.InMemory.SeedData;

namespace TheVideoGameStore.Inventory.Data.InMemory.Configurations;

class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(e => e.PlatformId);

        builder.Property(e => e.Name)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasData(PlatformSeedData.GetData());
    }
}
