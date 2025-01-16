using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Attribute = SmartPOS.Domain.Entities.Products.Attribute;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ProductConfigurations;

public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsMany(x => x.AttributeValues, av =>
        {
            av.ToTable("AttributeValues");
            av.WithOwner().HasForeignKey(x => x.AttributeId);
            av.HasKey(x => new {x.AttributeId, x.Id});
            av.Property(x => x.Id).ValueGeneratedOnAdd();
            av.Property(c => c.Value).IsRequired().HasMaxLength(100);
        });
    }
}
