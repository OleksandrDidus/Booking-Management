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

        public Task<Room> GetRoomByIdAsync(int id) => _roomRepository.GetRoomByIdAsync(id);
        public Task<IEnumerable<Room>> GetAllRoomsAsync() => _roomRepository.GetAllRoomsAsync();
        public Task AddRoomAsync(Room room) => _roomRepository.AddRoomAsync(room);
        public Task UpdateRoomAsync(Room room) => _roomRepository.UpdateRoomAsync(room);
        public Task DeleteRoomAsync(int id) => _roomRepository.DeleteRoomAsync(id);
    }

}
