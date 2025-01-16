using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.Transactions;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.TransactionConfigurations;

public abstract class BaseTransactionConfiguration<T> : IEntityTypeConfiguration<T> where T : ExternalEntityInventoryTransaction
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {

        ConfigurePayment(builder);
        ConfigureReturns(builder);
        ConfigureSafe(builder);
    }

    private void ConfigurePayment(EntityTypeBuilder<T> builder)
    {
        builder.OwnsOne(pt => pt.Payment, payment =>
        {
            payment.Property(p => p.PayedAmount).HasColumnType("decimal(18,2)").IsRequired();
            payment.Property(p => p.Type).IsRequired().HasDefaultValue(PaymentType.Unknown);
            payment.Property(p => p.Comment);
        });
    }

    private void ConfigureSafe(EntityTypeBuilder<T> builder)
    {
        builder.HasOne(x => x.Safe).WithMany().HasForeignKey(x => x.SafeId);
    }

    private void ConfigureReturns(EntityTypeBuilder<T> builder)
    {
        builder.OwnsMany(t => t.Returns, itemReturn =>
        {
            itemReturn.WithOwner().HasForeignKey(x => x.TransactionId);
            itemReturn.HasKey(x => x.Id);
            itemReturn.Property(x => x.Id).ValueGeneratedOnAdd();

            itemReturn.OwnsOne(pt => pt.Payment, payment =>
            {
                payment.Property(p => p.PayedAmount).HasColumnType("decimal(18,2)").IsRequired();
                payment.Property(p => p.Type).IsRequired().HasDefaultValue(PaymentType.Unknown);
                payment.Property(p => p.Comment);
            });

            itemReturn.OwnsMany(x => x.ReturnedItems, item =>
            {
                item.Property(p => p.UnitCost).HasColumnType("decimal(18,2)").IsRequired();
            });
        });
    }
}
