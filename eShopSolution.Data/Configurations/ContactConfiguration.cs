using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.phone_number).HasMaxLength(200).IsRequired();
            builder.Property(x => x.massage).IsRequired();
            builder.Property(x => x.status).HasDefaultValue(Status.Active);
        }
    }
}
