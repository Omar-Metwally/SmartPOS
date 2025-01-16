using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Domain.Entities.Inventory;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.AccountingConfigurations;

public class SerializedUnitConfiguration : IEntityTypeConfiguration<SerializedUnit>
{
    public void Configure(EntityTypeBuilder<SerializedUnit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.SerialNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => new { x.ProductInstanceId, x.UnitOfMeasureId })
            .IsRequired();

        builder.HasMany(x => x.StatusChanges).WithOne().HasForeignKey(x => x.SerializedUnitId);

        //builder.OwnsMany(su => su.StatusChanges, change =>
        //{
        //    change.WithOwner().HasForeignKey(x => x.SerializedUnitId);

        //    change.HasKey(x => x.Id);
        //    change.Property(x => x.Id).ValueGeneratedOnAdd();

        //    change.Property(x => x.ChangeDate)
        //        .IsRequired();

        //    change.Property(x => x.Status)
        //        .IsRequired();

        //    change.HasOne(x => x.ProductLevelChange)
        //        .WithMany(x => x.StatusChanges)
        //        .HasForeignKey(x => x.ProductLevelChangeId)
        //        .IsRequired(false);

        //    change.HasOne(x => x.OldWarehouse)
        //        .WithMany()
        //        .HasForeignKey(x => x.OldWarehouseId)
        //        .IsRequired(false);

        //    change.HasOne(x => x.NewWarehouse)
        //        .WithMany()
        //        .HasForeignKey(x => x.NewWarehouseId)
        //        .IsRequired(false);
        //});

        builder.HasIndex(x => new { x.ProductInstanceId, x.SerialNumber })
            .IsUnique();
    }
}