using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Products;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ProductConfigurations;

public class ProductInstanceConfiguration : IEntityTypeConfiguration<ProductInstance>
{
    public void Configure(EntityTypeBuilder<ProductInstance> builder)
    {
        builder.ToTable("ProductInstances");

        builder.HasOne(x => x.Product).WithMany(x => x.Instances).HasForeignKey(x => x.ProductId);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => x.Sku)
            .IsClustered(false)
            .IsUnique(true);

        builder.OwnsMany(x => x.Images, w =>
        {
            w.ToTable("ProductInstanceImages");

            w.Property(x => x.Path).HasConversion(
                v => v,
                v => Image.Create(v).Path
            );
            w.WithOwner().HasForeignKey();
            w.HasKey(x => x.Path);
        });

        builder.OwnsMany(x => x.AttributeValues, w =>
        {
            w.HasKey(x => new { x.ProductInstanceId, x.AttributeId, x.AttributeValueId });

            w.WithOwner().HasForeignKey(x => x.ProductInstanceId);

            w.HasOne(x => x.Attribute)
                .WithMany().HasForeignKey(x => x.AttributeId);

            w.HasIndex(x => new { x.ProductInstanceId, x.AttributeId })
                .IsUnique(true)
                .IsClustered(false);

            w.ToTable("ProductInstanceAttributeValues");

            w.ToTable(tb => tb.UseSqlOutputClause(false));
        });

        builder.HasMany(pi => pi.Prices)
            .WithOne(pi => pi.ProductInstance)
            .HasForeignKey(p => p.ProductInstanceId);
    }
}
