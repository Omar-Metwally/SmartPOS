using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Entities.Products;

namespace SmartPOS.Infrastructure.Persistence.Data.Configurations.ProductConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
            .HasForeignKey(d => d.ParentCategoryId);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.IsLeaf).HasDefaultValue(true);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.ToTable(tb => tb.UseSqlOutputClause(false));
    }
}
