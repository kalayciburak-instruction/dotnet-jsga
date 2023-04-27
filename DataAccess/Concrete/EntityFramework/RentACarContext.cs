using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var connectionString = configuration.GetConnectionString("PostgreSQL_Connection");

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException("PostgreSQL_Connection");
                }

                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(car =>
            {
                car.HasOne<Brand>()
                    .WithMany()
                    .HasForeignKey(c => c.BrandId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<Car>(car =>
            {
                car.HasIndex(c => c.ColorId).IsUnique(false);
                car.HasOne<Color>()
                    .WithMany()
                    .HasForeignKey(c => c.ColorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<CarImage>(image =>
            {
                image.HasIndex(i => i.CarId).IsUnique(false);
                image.HasOne<Car>()
                      .WithMany()
                      .HasForeignKey(i => i.CarId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
            });

            modelBuilder.Entity<Rental>(image =>
            {
                image.HasIndex(i => i.CarId).IsUnique(false);
                image.HasOne<Car>()
                      .WithMany()
                      .HasForeignKey(i => i.CarId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
            });
        }
    }
}
