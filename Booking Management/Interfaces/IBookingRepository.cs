using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingByIdAsync(int id);
        Task AddBookingAsync(Booking booking);
    }
}
