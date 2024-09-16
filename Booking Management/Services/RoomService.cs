using Booking_Management.Data.Model;
using Booking_Management.Interfaces;

namespace Booking_Management.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<ConferenceRoom>> GetAvailableRoomsAsync(DateTime date, int capacity)
        {
            return await _roomRepository.GetAvailableRooms(date, capacity);
        }

        public async Task<ConferenceRoom> GetRoomByIdAsync(int roomId)
        {
            return await _roomRepository.GetRoomByIdAsync(roomId);
        }

        public async Task AddRoomAsync(ConferenceRoom room)
        {
            await _roomRepository.AddRoomAsync(room);
        }

        public async Task UpdateRoomAsync(ConferenceRoom room)
        {
            await _roomRepository.UpdateRoomAsync(room);
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            await _roomRepository.DeleteRoomAsync(roomId);
        }
    }

}
