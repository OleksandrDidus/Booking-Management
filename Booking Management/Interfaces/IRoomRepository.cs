using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<ConferenceRoom>> GetAvailableRooms(DateTime date, int capacity);
        Task<ConferenceRoom> GetRoomByIdAsync(int id);
        Task AddRoomAsync(ConferenceRoom room);
        Task UpdateRoomAsync(ConferenceRoom room);
        Task DeleteRoomAsync(int roomId);
    }
}
