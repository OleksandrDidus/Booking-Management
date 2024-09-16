using Booking_Management.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Booking_Management.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ConferenceRoom> ConferenceRooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure initial data
            modelBuilder.Entity<ConferenceRoom>().HasData(
                new ConferenceRoom { Id = 1, Name = "Hall A", Capacity = 50, BasePricePerHour = 2000 },
                new ConferenceRoom { Id = 2, Name = "Hall B", Capacity = 100, BasePricePerHour = 3500 },
                new ConferenceRoom { Id = 3, Name = "Hall C", Capacity = 30, BasePricePerHour = 1500 }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Projector", Price = 500 },
                new Service { Id = 2, Name = "Wi-Fi", Price = 300 },
                new Service { Id = 3, Name = "Sound", Price = 700 }
            );
        }
    }

}
