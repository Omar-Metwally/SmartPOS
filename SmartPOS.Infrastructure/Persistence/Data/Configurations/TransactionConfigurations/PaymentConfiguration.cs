using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.TransactionConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<PaymentTransaction>
{
    public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
    {
        builder.HasOne(pt => pt.Party)
            .WithMany()
            .HasForeignKey(pt => pt.PartyId)
            .IsRequired();

        builder.HasOne(x => x.Safe).WithMany().HasForeignKey(x => x.SafeId);

        builder.OwnsOne(pt => pt.Payment, payment =>
        {
            payment.Property(p => p.PayedAmount).HasColumnType("decimal(18,2)").IsRequired();
            payment.Property(p => p.Type).IsRequired().HasDefaultValue(PaymentType.Unknown);
            payment.Property(p => p.Comment);
        });
    }
}
