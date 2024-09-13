using Booking_Management.Data.Model;
using Booking_Management.Data;
using Booking_Management.Interfaces;

namespace Booking_Management.Repos
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> GetBookingByIdAsync(int id) => await _context.Bookings.FindAsync(id);
        public async Task AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
    }
}
