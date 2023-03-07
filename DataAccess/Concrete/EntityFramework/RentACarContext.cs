using Core.CrossCuttingConcerns.Security;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationsClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Findeks> Findeks { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=rent-a-car; Username=postgres; Password=12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationClaim>(o =>
            {
                o.ToTable("OperationClaims").HasKey("Id");
                o.Property(o => o.Id).HasColumnName("Id");
                o.Property(o=>o.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<Customer>(c =>
            {
                c.ToTable("Customers").HasKey("Id");
                c.Property(c => c.Id).HasColumnName("Id");
                c.Property(c => c.UserId).HasColumnName("UserId");
                c.Property(c => c.CompanyName).HasColumnName("CompanyName");
                c.HasOne(c => c.User);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey("Id");
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.FirstName).HasColumnName("FirstName");
                u.Property(u => u.LastName).HasColumnName("LastName");
                u.Property(u => u.NationalIdentity).HasColumnName("NationalIdentity");
                u.Property(u => u.Email).HasColumnName("Email");
                u.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                u.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(u => u.Status).HasColumnName("Status");
                
            });

            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brands").HasKey("Id");
                b.Property(b => b.Id).HasColumnName("Id");
                b.Property(b => b.Name).HasColumnName("Name").IsRequired();
            });

            modelBuilder.Entity<Color>(c =>
            {
                c.ToTable("Colors").HasKey("Id");
                c.Property(c => c.Id).HasColumnName("Id");
                c.Property(c => c.Name).HasColumnName("Name").IsRequired();
            });

            modelBuilder.Entity<Rental>(f =>
            {
                f.ToTable("Rentals").HasKey("Id");
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.CustomerId).HasColumnName("CustomerId");
                f.Property(f => f.CarId).HasColumnName("CarId");
                f.Property(f => f.StartDate).HasColumnName("StartDate");
                f.Property(f => f.EndDate).HasColumnName("EndDate");
                f.Property(f => f.ReturnDate).HasColumnName("ReturnDate");
                f.HasOne(f => f.Car);
                f.HasOne(f => f.Customer);
            });

            modelBuilder.Entity<Car>(m =>
            {
                m.ToTable("Cars").HasKey("Id");
                m.Property(m => m.Id).HasColumnName("Id");
                m.Property(m => m.Name).HasColumnName("Name");
                m.Property(m => m.Plate).HasColumnName("Plate");
                m.Property(m => m.ModelYear).HasColumnName("ModelYear");
                m.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
                m.Property(m => m.Description).HasColumnName("Description");
                m.Property(m => m.Kilometer).HasColumnName("Kilometer");
                m.Property(m => m.BrandId).HasColumnName("BrandId");
                m.Property(m => m.MinFindeksScore).HasColumnName("MinFindeksScore");
                m.Property(m => m.CarImageId).HasColumnName("CarImageId");
                m.Property(m => m.ColorId).HasColumnName("ColorId");
                m.HasOne(m => m.Brand);
                m.HasOne(m => m.Color);
                m.HasOne(m => m.CarImage);
            });

            modelBuilder.Entity<CarImage>(c =>
            {
                c.ToTable("CarImages").HasKey("Id");
                c.Property(c => c.Id).HasColumnName("Id");
                c.Property(c => c.Date).HasColumnName("Date");
                c.Property(c => c.ImagePath).HasColumnName("ImagePath");
            });

            modelBuilder.Entity<Findeks>(f =>
            {
                f.ToTable("Findeks").HasKey("Id");
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.CustomerId).HasColumnName("CustomerId");
                f.Property(f => f.Score).HasColumnName("Score");
                f.HasOne(f => f.Customer);
            });
        }

    }
}
