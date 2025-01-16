using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Products;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ProductConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.ModelNumber)
            .IsRequired();

        builder.HasOne(d => d.Manufacturer)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.ManufacturerId);

        builder.HasOne(d => d.Category)
            .WithMany()
            .HasForeignKey(d => d.CategoryId);

        //builder.OwnsMany(p => p.Units, unitBuilder =>
        //{
        //    unitBuilder.WithOwner().HasForeignKey(x => x.ProductId);
        //    unitBuilder.HasKey(x => new { x.ProductId, x.UnitOfMeasureID });
        //    unitBuilder.HasOne(x => x.UnitOfMeasure)
        //        .WithMany()
        //        .HasForeignKey(x => x.UnitOfMeasureID);
        //});

        //builder.OwnsMany(d => d.Instances, instanceBuilder =>
        //{
        //    instanceBuilder.WithOwner().HasForeignKey(x => x.ProductId);
        //    instanceBuilder.HasKey(x => x.Id);
        //    instanceBuilder.Property(x => x.Id).ValueGeneratedOnAdd();

        //    instanceBuilder.HasIndex(x => x.Sku)
        //        .IsClustered(false)
        //        .IsUnique(true);

        //    instanceBuilder.OwnsMany(x => x.Images, w =>
        //    {
        //        w.Property(x => x.Path).HasConversion(
        //            v => v,
        //            v => Image.Create(v).Path
        //        );
        //        w.WithOwner().HasForeignKey();
        //        w.HasKey(x => x.Path);
        //    });

        //    instanceBuilder.OwnsMany(x => x.AttributeValues, w =>
        //    {
        //        w.HasKey(x => new { x.ProductInstanceId, x.AttributeId, x.AttributeValueId });

        //        w.WithOwner().HasForeignKey(x => x.ProductInstanceId);

        //        w.HasOne(x => x.Attribute)
        //            .WithMany().HasForeignKey(x => new { x.AttributeId, x.AttributeValueId });

        //        w.HasIndex(x => new { x.ProductInstanceId, x.AttributeId })
        //            .IsUnique(true)
        //            .IsClustered(false);

        //        w.ToTable(tb => tb.UseSqlOutputClause(false));
        //    });

        //    instanceBuilder.OwnsMany(x => x.Prices, priceBuilder =>
        //    {
        //        priceBuilder.WithOwner().HasForeignKey(x => x.ProductInstanceId);

        //        priceBuilder.HasKey(x => new { x.ProductInstanceId, x.UnitOfMeasureID });

        //        priceBuilder.HasOne(x => x.UnitOfMeasure)
        //            .WithMany()
        //            .HasForeignKey(x => x.UnitOfMeasureID);

        //        priceBuilder.Property(x => x.SellingPrice)
        //            .HasPrecision(18, 2);
        //    });
        //});

        builder.ToTable(tb => tb.UseSqlOutputClause(false));
    }
}
