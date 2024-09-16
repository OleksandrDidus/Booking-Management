using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> BookRoomAsync(int roomId, DateTime startTime, TimeSpan duration, List<int> selectedServiceIds);
        decimal CalculateTotalCost(ConferenceRoom room, DateTime startTime, TimeSpan duration, IEnumerable<Service> services);
    }
}
