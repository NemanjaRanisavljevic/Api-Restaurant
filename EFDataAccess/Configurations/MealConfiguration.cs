using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(m => m.Finish)
               .IsRequired();

            builder.Property(m => m.Start)
               .IsRequired();

            builder.HasMany(m => m.MeniMeals)
                .WithOne(mm => mm.Meal)
                .HasForeignKey(mm => mm.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(m => m.ModifieAt).HasDefaultValueSql("GETDATE()");
            builder.Property(m => m.IsDeleted).HasDefaultValue(false);
        }

    }
}
