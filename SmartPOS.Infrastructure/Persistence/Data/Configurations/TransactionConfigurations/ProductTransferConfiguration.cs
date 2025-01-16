using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.TransactionConfigurations;

public class ProductTransferConfiguration : IEntityTypeConfiguration<ProductTransferTransaction>
{
    public void Configure(EntityTypeBuilder<ProductTransferTransaction> builder)
    {
        builder.HasOne(x => x.Warehouse).WithMany().HasForeignKey(x => x.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ReceivingWarehouse).WithMany().HasForeignKey(x => x.ReceivingWarehouseId).OnDelete(DeleteBehavior.Restrict);

        builder.OwnsMany(it => it.Items, item =>
        {
            item.WithOwner().HasForeignKey(x => x.InventoryTransactionId);
            item.HasKey(x => x.Id);
            item.Property(x => x.Id).ValueGeneratedOnAdd();

            item.Property(p => p.UnitCost).HasColumnType("decimal(18,2)").IsRequired();

            item.HasOne(x => x.Unit).WithMany().HasForeignKey(x => new { x.ProductInstanceId, x.UnitOfMeasureID });
        });
    }
}
