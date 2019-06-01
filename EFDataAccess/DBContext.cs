using Domain;
using EFDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess
{
    public class DBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Meni> Menis { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MeniMeal> MeniMeals { get; set; }

        public DbSet<Impression> Impressions { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=APIRestoran;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DrinkConfiguratin());
            modelBuilder.ApplyConfiguration(new ImpressionConfiguration());
            modelBuilder.ApplyConfiguration(new MealConfiguration());
            modelBuilder.ApplyConfiguration(new MeniConfiguration());
            modelBuilder.ApplyConfiguration(new MeniMealConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new RuleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }
    }
}
