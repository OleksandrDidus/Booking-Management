using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IRoomService
    {
        Task<List<ConferenceRoom>> GetAvailableRoomsAsync(DateTime date, int capacity);
        Task<ConferenceRoom> GetRoomByIdAsync(int roomId);
        Task AddRoomAsync(ConferenceRoom room);
        Task UpdateRoomAsync(ConferenceRoom room);
        Task DeleteRoomAsync(int roomId);
    }
}
