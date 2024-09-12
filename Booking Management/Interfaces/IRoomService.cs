using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IRoomService
    {
        Task<Room> GetRoomByIdAsync(int id);
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(int id);
    }
}
