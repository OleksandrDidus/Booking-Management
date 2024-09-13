using Booking_Management.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Booking_Management.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Налаштування для моделі User, Room та Booking, якщо потрібно
        }
    }

}
