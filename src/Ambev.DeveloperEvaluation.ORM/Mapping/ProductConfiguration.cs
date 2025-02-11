using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(a => a.Title).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Price);
            builder.Property(a => a.Description).HasMaxLength(200);
            builder.Property(a => a.Category).HasMaxLength(50);
            builder.Property(a => a.Image).HasMaxLength(200);
            builder.Property(a => a.RatingRate);
            builder.Property(a => a.RatingCount);
        }
    }
}
