using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(t => new { t.category_id, t.product_id });

            builder.ToTable("ProductInCategories");

            builder.HasOne(t => t.product).WithMany(pc => pc.ProductInCategories).HasForeignKey(pc => pc.product_id);

            builder.HasOne(t => t.category).WithMany(pc => pc.ProductInCategories).HasForeignKey(pc => pc.category_id);
        }
    }
}
