using Booking_Management.Data.Model;
using Booking_Management.Data;
using Booking_Management.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Booking_Management.Repos
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConferenceRoom>> GetAvailableRooms(DateTime date, int capacity)
        {
            return await _context.ConferenceRooms
                .Where(r => r.Capacity >= capacity && !_context.Bookings
                    .Any(b => b.ConferenceRoomId == r.Id && b.StartTime.Date == date.Date))
                .Include(r => r.Services)
                .ToListAsync();
        }

        public async Task<ConferenceRoom> GetRoomByIdAsync(int id)
        {
            return await _context.ConferenceRooms.Include(r => r.Services).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRoomAsync(ConferenceRoom room)
        {
            await _context.ConferenceRooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(ConferenceRoom room)
        {
            _context.ConferenceRooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            var room = await _context.ConferenceRooms.FindAsync(roomId);
            if (room != null)
            {
                _context.ConferenceRooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}
