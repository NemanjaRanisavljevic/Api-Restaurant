using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired();
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Active)
                .HasDefaultValue(false);

            builder.Property(u => u.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.ModifieAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);


        }
    }
}
