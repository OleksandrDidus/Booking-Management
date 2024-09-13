using Booking_Management.Data.Model;
using Booking_Management.Data;
using Booking_Management.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking_Management.Repos
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Room> GetRoomByIdAsync(int id) => await _context.Rooms.FindAsync(id);
        public async Task<IEnumerable<Room>> GetAllRoomsAsync() => await _context.Rooms.ToListAsync();
        public async Task AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = await GetRoomByIdAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}
