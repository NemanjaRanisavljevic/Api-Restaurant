using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ImpressionConfiguration : IEntityTypeConfiguration<Impression>
    {
        public void Configure(EntityTypeBuilder<Impression> builder)
        {
            builder.Property(i => i.Content)
                .IsRequired();

            builder.Property(i => i.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(i => i.ModifieAt).HasDefaultValueSql("GETDATE()");
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
        }
    }
}
