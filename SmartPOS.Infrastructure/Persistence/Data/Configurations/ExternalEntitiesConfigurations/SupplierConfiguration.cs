using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.ExternalEntities;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ExternalEntitiesConfigurations;

internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");

        builder.OwnsMany(x => x.Contacts, contacts =>
        {
            contacts.ToTable("SupplierContacts");
            contacts.WithOwner().HasForeignKey("SupplierId");
            contacts.HasKey("Id");
            contacts.Property<int>("Id").ValueGeneratedOnAdd();

            contacts.Property(c => c.Name).IsRequired().HasMaxLength(200);
            contacts.OwnsOne(c => c.PhoneNumber, phone =>
            {
                phone.Property(p => p.Number)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(20);
            });
        });

        builder.OwnsMany(x => x.Addresses, addresses =>
        {
            addresses.ToTable("SupplierAddresses");
            addresses.WithOwner().HasForeignKey("SupplierId");
            addresses.HasKey("Id");
            addresses.Property<int>("Id").ValueGeneratedOnAdd();

            addresses.Property(a => a.Street).IsRequired().HasMaxLength(200);
            addresses.Property(a => a.City).IsRequired().HasMaxLength(100);
            addresses.Property(a => a.State).HasMaxLength(50);
            addresses.Property(a => a.PostalCode).HasMaxLength(20);
            addresses.Property(a => a.Country).IsRequired().HasMaxLength(100);
        });
    }
}