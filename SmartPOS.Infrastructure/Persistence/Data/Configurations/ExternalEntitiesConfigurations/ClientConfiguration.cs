using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Domain.Entities.ExternalEntities;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ExternalEntitiesConfigurations;

internal class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.OwnsMany(x => x.Contacts, contacts =>
        {
            contacts.ToTable("ClientContacts");
            contacts.WithOwner().HasForeignKey("ClientId");
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
            addresses.ToTable("ClientAddresses");
            addresses.WithOwner().HasForeignKey("ClientId");
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