using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.TransactionConfigurations;

public class CustomerSalesConfiguration : BaseTransactionConfiguration<CustomerSalesTransaction>
{
    public override void Configure(EntityTypeBuilder<CustomerSalesTransaction> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.DeliveryDetails, dd =>
        {
            dd.OwnsOne(x => x.Address, address =>
            {
                address.Property(a => a.Street).IsRequired().HasMaxLength(200);
                address.Property(a => a.City).IsRequired().HasMaxLength(100);
                address.Property(a => a.State).HasMaxLength(50);
                address.Property(a => a.PostalCode).HasMaxLength(20);
                address.Property(a => a.Country).IsRequired().HasMaxLength(100);
            });

            dd.OwnsOne(x => x.PhoneNumber, phoneNumber =>
            {
                phoneNumber.Property(p => p.Number)
                        .HasColumnName("PhoneNumber")
                        .HasMaxLength(20);
            });
        });

        builder.OwnsMany(it => it.Items, item =>
        {
            item.WithOwner().HasForeignKey(x => x.InventoryTransactionId);
            item.HasKey(x => x.Id);
            item.Property(x => x.Id).ValueGeneratedOnAdd();

            item.Property(p => p.UnitCost).HasColumnType("decimal(18,2)").IsRequired();

            item.Property(p => p.UnitPriceBeforeDiscount).HasColumnType("decimal(18,2)").IsRequired();

            item.Property(p => p.DiscountPercentage)
                .IsRequired()
                .HasDefaultValue(0);

            item.Ignore(x => x.UnitPriceAfterDiscount);

            item.HasOne(x => x.Unit).WithMany().HasForeignKey(x => new { x.ProductInstanceId, x.UnitOfMeasureID });
        });
    }
}
