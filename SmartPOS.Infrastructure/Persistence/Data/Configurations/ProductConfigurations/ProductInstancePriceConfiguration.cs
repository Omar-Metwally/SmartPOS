using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Products;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ProductConfigurations;

public class ProductInstancePriceConfiguration : IEntityTypeConfiguration<ProductInstancePrice>
{
    public void Configure(EntityTypeBuilder<ProductInstancePrice> builder)
    {
        builder.ToTable("ProductInstancePrices");
        builder.HasOne(x => x.UnitOfMeasure).WithMany().HasForeignKey(x => x.UnitOfMeasureId);
        builder.HasKey(x => new { x.ProductInstanceId, x.UnitOfMeasureId });
        builder.Property(p => p.SellingPrice).HasColumnType("decimal(18,2)").IsRequired();
    }
}