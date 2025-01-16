using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.TransactionConfigurations;

public class SafeTransferConfiguration : IEntityTypeConfiguration<SafeTransferTransaction>
{
    public void Configure(EntityTypeBuilder<SafeTransferTransaction> builder)
    {
        builder.OwnsOne(pt => pt.Payment, payment =>
        {
            payment.Property(p => p.PayedAmount).HasColumnType("decimal(18,2)").IsRequired();
            payment.Property(p => p.Type).IsRequired().HasDefaultValue(PaymentType.Unknown);
            payment.Property(p => p.Comment);
        });

        builder.HasOne(x => x.Safe).WithMany().HasForeignKey(x => x.SafeId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ReceivingSafe).WithMany().HasForeignKey(x => x.ReceivingSafeId).OnDelete(DeleteBehavior.Restrict);

    }
}
