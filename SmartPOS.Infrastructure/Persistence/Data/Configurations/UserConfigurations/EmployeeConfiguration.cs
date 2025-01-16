using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Users;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.UserConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Bonus).HasColumnType("decimal(18,2)");

        builder.OwnsOne(x => x.Address, addresses =>
        {
            addresses.Property(a => a.Street).IsRequired().HasMaxLength(200);
            addresses.Property(a => a.City).IsRequired().HasMaxLength(100);
            addresses.Property(a => a.State).HasMaxLength(50);
            addresses.Property(a => a.PostalCode).HasMaxLength(20);
            addresses.Property(a => a.Country).IsRequired().HasMaxLength(100);
        });
    }
}
