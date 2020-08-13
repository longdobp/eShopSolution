using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).UseIdentityColumn();

            builder.Property(x => x.image_path).HasMaxLength(200).IsRequired();

            builder.Property(x => x.caption).HasMaxLength(200);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.product_id);
        }
    }
}
