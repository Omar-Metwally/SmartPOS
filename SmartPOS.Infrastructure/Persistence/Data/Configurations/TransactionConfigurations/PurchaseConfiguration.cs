using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.TransactionConfigurations;

public class PurchaseConfiguration : BaseTransactionConfiguration<PurchaseTransaction>
{
    public override void Configure(EntityTypeBuilder<PurchaseTransaction> builder)
    {
        base.Configure(builder);

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
