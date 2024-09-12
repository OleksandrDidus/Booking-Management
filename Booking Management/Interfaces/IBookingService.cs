using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IBookingService
    {
        Task<decimal> CalculateTotalPrice(Room room, DateTime startTime, int duration, List<Service> selectedServices);
        Task AddBookingAsync(Booking booking);
    }
}
