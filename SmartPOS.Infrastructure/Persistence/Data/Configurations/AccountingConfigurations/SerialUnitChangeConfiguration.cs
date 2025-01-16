using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Accounting;
using SmartPOS.Domain.Entities.Inventory;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.AccountingConfigurations;

public class SerialUnitChangeConfiguration : IEntityTypeConfiguration<SerialUnitChange>
{
    public void Configure(EntityTypeBuilder<SerialUnitChange> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.ChangeDate)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasOne(x => x.SerializedUnit)
            .WithMany(x => x.StatusChanges)
            .HasForeignKey(x => x.SerializedUnitId);
    }
}