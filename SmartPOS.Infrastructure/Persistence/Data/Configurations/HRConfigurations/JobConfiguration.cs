using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.HR;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.HRConfigurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("Jobs");
        builder.HasKey(x => x.Id);
        builder.Property(p => p.BaseSalary).HasColumnType("decimal(18,2)");
    }
}
