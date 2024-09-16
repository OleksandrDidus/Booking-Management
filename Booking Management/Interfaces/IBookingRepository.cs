using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IBookingRepository
    {
        Task AddBookingAsync(Booking booking);
        Task<List<Booking>> GetBookingsBetweenDatesAsync(DateTime startDate, DateTime endDate);
    }

}
