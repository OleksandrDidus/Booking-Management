using Booking_Management.Data.Model;
using Booking_Management.Interfaces;

namespace Booking_Management.Services
{
    public class ReportService : IReportService
    {
        private readonly IBookingRepository _bookingRepository;

        public ReportService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<List<RoomUsageReport>> GenerateRoomUsageReportAsync(DateTime startDate, DateTime endDate)
        {
            var bookings = await _bookingRepository.GetBookingsBetweenDatesAsync(startDate, endDate);

            var report = bookings
                .GroupBy(b => b.ConferenceRoom.Name)
                .Select(g => new RoomUsageReport
                {
                    RoomName = g.Key,
                    TotalBookings = g.Count(),
                    TotalRevenue = g.Sum(b => b.TotalCost)
                })
                .ToList();

            return report;
        }
    }
}
