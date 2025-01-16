using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.TransactionConfigurations;

//public class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
//{
//    public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
//    {
//        builder.OwnsMany(it => it.Items, item =>
//        {
//            item.WithOwner().HasForeignKey(x => x.InventoryTransactionId);
//            item.HasKey(x => x.Id);
//            item.Property(x => x.Id).ValueGeneratedOnAdd();
//            item.Property(p => p.UnitPriceBeforeDiscount).HasColumnType("decimal(18,2)").IsRequired();

//            item.Property(p => p.DiscountPercentage)
//                .IsRequired()
//                .HasDefaultValue(0);

//            item.Ignore(x => x.UnitPriceAfterDiscount);

//            item.HasOne(x => x.Unit).WithMany().HasForeignKey(x => new { x.ProductInstanceId, x.UnitOfMeasureID });
//        });
//    }
//}
