using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.seo_alias).IsRequired().HasMaxLength(200);
            builder.Property(x => x.details).HasMaxLength(500);
            builder.Property(x => x.language_id).IsUnicode(false).IsRequired().HasMaxLength(5);
            builder.HasOne(x => x.language).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.language_id);
            builder.HasOne(x => x.product).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.product_id);
        }
    }
}