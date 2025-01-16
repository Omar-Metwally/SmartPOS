using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Organization;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.OrganizationConfigurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(x => x.Manager).WithMany().HasForeignKey(x => x.ManagerId);

        builder.HasMany(x => x.Employees).WithOne(x => x.Branch).HasForeignKey(x => x.BranchId);

        builder.OwnsOne(x => x.Address, address =>
        {
            address.WithOwner();
            address.Ignore(a => a.Id);
            address.Property(a => a.Street).IsRequired().HasMaxLength(200);
            address.Property(a => a.City).IsRequired().HasMaxLength(100);
            address.Property(a => a.State).HasMaxLength(50);
            address.Property(a => a.PostalCode).HasMaxLength(20);
            address.Property(a => a.Country).IsRequired().HasMaxLength(100);
        });
    }
}
