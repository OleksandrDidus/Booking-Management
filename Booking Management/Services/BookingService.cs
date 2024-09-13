using Booking_Management.Data.Model;
using Booking_Management.Interfaces;

namespace Booking_Management.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public decimal CalculateTotalPrice(Room room, DateTime startTime, int duration, List<Service> selectedServices)
        {
            decimal totalPrice = room.BasePricePerHour * duration;

            // Логіка розрахунку вартості в залежності від часу
            if (startTime.Hour >= 6 && startTime.Hour < 9)
            {
                totalPrice *= 0.9M;
            }
            else if (startTime.Hour >= 18 && startTime.Hour < 23)
            {
                totalPrice *= 0.8M;
            }
            else if (startTime.Hour >= 12 && startTime.Hour < 14)
            {
                totalPrice *= 1.15M;
            }

            // Додаємо вартість послуг
            foreach (var service in selectedServices)
            {
                totalPrice += service.Price;
            }

            return totalPrice;
        }

        public Task AddBookingAsync(Booking booking) => _bookingRepository.AddBookingAsync(booking);
    }
}
