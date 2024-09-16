using Booking_Management.Data.Model;
using Booking_Management.Data;
using Booking_Management.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace Booking_Management.Repos
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Booking>> GetBookingsBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings
                .Include(b => b.ConferenceRoom)
                .Where(b => b.StartTime >= startDate && b.EndTime <= endDate)
                .ToListAsync();
        }

    }
}
