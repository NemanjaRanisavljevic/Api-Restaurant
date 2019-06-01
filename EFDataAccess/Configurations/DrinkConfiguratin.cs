using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class DrinkConfiguratin : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.Property(d => d.DrinkName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.ModifieAt).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.IsDeleted).HasDefaultValue(false);
        }
    }
}
