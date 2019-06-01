using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class RuleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.NameRole)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(r => r.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.ModifieAt).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);
        }
    }
}
