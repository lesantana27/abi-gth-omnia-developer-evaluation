using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(a => a.CartId);
            builder.Property(a => a.ProductId);
            builder.Property(a => a.Title).HasMaxLength(50);
            builder.Property(a => a.Price);
            builder.Property(a => a.Quantity);
            builder.Property(a => a.Discount);
            builder.Property(a => a.TotalAmount);
            builder.Property(a => a.ItemCanceled);

            builder.HasOne(a => a.Cart).WithMany(a => a.CartItemList).HasForeignKey(a => a.CartId).IsRequired();
        }
    }
}
