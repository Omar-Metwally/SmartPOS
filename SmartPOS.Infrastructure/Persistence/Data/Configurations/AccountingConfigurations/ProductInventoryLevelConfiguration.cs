using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Accounting;
using SmartPOS.Domain.Entities.Inventory;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.AccountingConfigurations;

public class ProductInventoryLevelConfiguration : IEntityTypeConfiguration<ProductInventoryLevel>
{
    public void Configure(EntityTypeBuilder<ProductInventoryLevel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.HasOne(x => x.ProductInstance)
            .WithMany()
            .HasForeignKey(x => new { x.ProductInstanceId, x.UnitOfMeasureId })
            .IsRequired();

        builder.HasOne(x => x.Warehouse)
            .WithMany()
            .HasForeignKey(x => x.WarehouseId)
            .IsRequired();

        builder.HasMany(x => x.Changes)
            .WithOne()
            .HasForeignKey(x => x.ProductInventoryLevelId)
            .IsRequired();

        //builder.OwnsMany(pil => pil.Changes, change =>
        //{
        //    change.HasKey(x => x.Id);
        //    change.Property(x => x.Id).ValueGeneratedOnAdd();

        //    change.Property(x => x.ChangeDate)
        //        .IsRequired();

        //    change.Property(x => x.ChangeType)
        //        .IsRequired();

        //    change.HasOne(x => x.Transaction)
        //        .WithMany()
        //        .HasForeignKey(x => x.TransactionId)
        //        .IsRequired(false);
        //});

        builder.HasMany(x => x.SerializedUnits)
            .WithOne()
            .HasForeignKey(x => x.ProductInventoryLevelId)
            .IsRequired(false);

        builder.HasIndex(x => new { x.ProductInstanceId, x.UnitOfMeasureId, x.WarehouseId })
            .IsUnique();
    }
}