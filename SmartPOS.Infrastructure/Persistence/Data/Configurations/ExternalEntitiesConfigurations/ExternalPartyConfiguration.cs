using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Domain.Entities.ExternalEntities;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ExternalEntitiesConfigurations;

internal class ExternalPartyConfiguration : IEntityTypeConfiguration<ExternalParty>
{
    public void Configure(EntityTypeBuilder<ExternalParty> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Type)
            .IsRequired();

        builder.UseTpcMappingStrategy();
    }
}