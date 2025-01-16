using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Domain.Entities.ExternalEntities;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ExternalEntitiesConfigurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.Property(x => x.Comment)
            .HasMaxLength(500);

        builder.OwnsOne(x => x.PhoneNumber, phone =>
        {
            phone.Property(p => p.Number)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(20);
        });

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