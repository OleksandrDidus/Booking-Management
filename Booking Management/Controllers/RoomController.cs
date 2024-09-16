using Booking_Management.Data.Model;
using Booking_Management.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoom([FromBody] ConferenceRoom room)
        {
            await _roomService.AddRoomAsync(room);
            return Ok("Room added successfully!");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] ConferenceRoom updatedRoom)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null) return NotFound("Room not found");

            room.Name = updatedRoom.Name;
            room.Capacity = updatedRoom.Capacity;
            room.BasePricePerHour = updatedRoom.BasePricePerHour;
            room.Services = updatedRoom.Services;

            await _roomService.UpdateRoomAsync(room);
            return Ok("Room updated successfully!");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return Ok("Room deleted successfully!");
        }

        [HttpGet("available")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] DateTime date, [FromQuery] int capacity)
        {
            var availableRooms = await _roomService.GetAvailableRoomsAsync(date, capacity);
            return Ok(availableRooms);
        }
    }
}
