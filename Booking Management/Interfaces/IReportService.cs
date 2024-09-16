using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IReportService
    {
        Task<List<RoomUsageReport>> GenerateRoomUsageReportAsync(DateTime startDate, DateTime endDate);
    }
}
