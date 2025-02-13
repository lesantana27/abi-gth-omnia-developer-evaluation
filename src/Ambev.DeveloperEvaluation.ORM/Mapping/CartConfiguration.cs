using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(a => a.SaleNumber);
            builder.Property(a => a.Date);
            builder.Property(a => a.UserId);
            builder.Property(a => a.TotalAmount);
            builder.Property(a => a.BranchName).HasMaxLength(50);

            builder.HasOne(a => a.User).WithMany(a => a.CartList).HasForeignKey(a => a.UserId).IsRequired();

        }
    }
}
