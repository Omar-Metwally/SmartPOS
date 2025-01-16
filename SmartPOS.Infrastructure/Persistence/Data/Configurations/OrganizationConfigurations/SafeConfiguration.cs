using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Organization;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.OrganizationConfigurations;

public class SafeConfiguration : IEntityTypeConfiguration<Safe>
{
    public void Configure(EntityTypeBuilder<Safe> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.CashStartBalance)
            .HasPrecision(18, 2);

        builder.Property(x => x.VISAStartBalance)
            .HasPrecision(18, 2);

        builder.Property(x => x.ChequeStartBalance)
            .HasPrecision(18, 2);
    }
}
