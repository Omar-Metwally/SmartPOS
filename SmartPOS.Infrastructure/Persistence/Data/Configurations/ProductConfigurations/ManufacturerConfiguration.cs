using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Products;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ProductConfigurations;

public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(d => d.Products).WithOne(p => p.Manufacturer)
            .HasForeignKey(d => d.ManufacturerId);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
