using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).UseIdentityColumn();

            builder.Property(x => x.price).IsRequired();

            builder.Property(x => x.stock).IsRequired().HasDefaultValue(0);

            builder.Property(x => x.view_count).IsRequired().HasDefaultValue(0);
        }
    }
}
