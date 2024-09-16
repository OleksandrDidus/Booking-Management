using Booking_Management.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(int roomId, DateTime startTime, int durationInHours, [FromBody] List<int> selectedServiceIds)
        {
            try
            {
                var booking = await _bookingService.BookRoomAsync(roomId, startTime, TimeSpan.FromHours(durationInHours), selectedServiceIds);
                return Ok(new { message = "Room booked successfully!", totalCost = booking.TotalCost });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
