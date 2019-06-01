using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class MeniMealConfiguration : IEntityTypeConfiguration<MeniMeal>
    {
        public void Configure(EntityTypeBuilder<MeniMeal> builder)
        {
            builder.HasKey(mm => new { mm.MeniId, mm.MealId});
        }
    }
}
