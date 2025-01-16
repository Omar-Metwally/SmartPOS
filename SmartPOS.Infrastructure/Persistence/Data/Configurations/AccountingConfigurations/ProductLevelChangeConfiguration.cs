using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Domain.Entities.Inventory;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.AccountingConfigurations;

public class ProductLevelChangeConfiguration : IEntityTypeConfiguration<ProductLevelChange>
{
    public void Configure(EntityTypeBuilder<ProductLevelChange> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.ChangeDate)
            .IsRequired();

        builder.Property(x => x.ChangeType)
            .IsRequired();

        builder.Property(x => x.PreviousQuantity)
            .IsRequired();

        builder.Property(x => x.ChangedQuantity)
            .IsRequired();

        builder.Property(x => x.NewQuantity)
            .IsRequired();

        builder.HasOne(x => x.Transaction)
            .WithMany()
            .HasForeignKey(x => x.TransactionId)
            .IsRequired(false);

        builder.HasMany(x => x.StatusChanges)
            .WithOne(x => x.ProductLevelChange)
            .HasForeignKey(x => x.ProductLevelChangeId)
            .IsRequired(false);
    }
}