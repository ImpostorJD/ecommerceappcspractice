using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataglog.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name).HasMaxLength(255).IsRequired();

        builder.Property(p => p.Category).IsRequired();

        builder.Property(p => p.Description).HasMaxLength(255);

        builder.Property(p => p.ImageFile).HasMaxLength(255);

        builder.Property(p => p.Price).IsRequired();
     }
}