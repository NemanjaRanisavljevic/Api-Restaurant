using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.ReservationDate)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.Guest)
                .IsRequired();

            builder.Property(r => r.Time)
                .IsRequired();

            builder.Property(r => r.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.ModifieAt).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);

        }
    }
}
