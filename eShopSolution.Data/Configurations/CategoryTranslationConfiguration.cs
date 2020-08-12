using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslations");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).UseIdentityColumn();

            builder.Property(x => x.seo_description).HasMaxLength(500);

            builder.Property(x => x.seo_title).HasMaxLength(200);

            builder.Property(x => x.seo_alias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.language_id).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(x => x.language).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.language_id);

            builder.HasOne(x => x.category).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.category_id);
        }
    }
}
