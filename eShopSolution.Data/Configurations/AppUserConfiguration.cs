using eShopSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(x => x.first_name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.last_name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.date_of_birth).IsRequired();
        }
    }
}
