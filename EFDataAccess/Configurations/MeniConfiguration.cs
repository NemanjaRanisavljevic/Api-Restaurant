using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class MeniConfiguration : IEntityTypeConfiguration<Meni>
    {
        public void Configure(EntityTypeBuilder<Meni> builder)
        {
            builder.Property(m => m.NameFood)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(m => m.Ingrediant)
               .IsRequired();

            builder.Property(m => m.Price)
               .IsRequired();

            builder.HasMany(m => m.MeniMeals)
                .WithOne(mm => mm.Meni)
                .HasForeignKey(mm => mm.MeniId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(u => u.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.ModifieAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);
        }

        
    }
}
