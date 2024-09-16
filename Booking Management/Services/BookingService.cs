using Booking_Management.Data.Model;
using Booking_Management.Interfaces;

namespace Booking_Management.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IServiceRepository _serviceRepository;

        public BookingService(IRoomRepository roomRepository, IBookingRepository bookingRepository, IServiceRepository serviceRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<Booking> BookRoomAsync(int roomId, DateTime startTime, TimeSpan duration, List<int> selectedServiceIds)
        {
            var room = await _roomRepository.GetRoomByIdAsync(roomId);
            if (room == null)
                throw new Exception("Room not found");

            var services = await _serviceRepository.GetServicesByIdsAsync(selectedServiceIds);

            var totalCost = CalculateTotalCost(room, startTime, duration, services);

            var booking = new Booking
            {
                ConferenceRoomId = roomId,
                StartTime = startTime,
                EndTime = startTime.Add(duration),
                SelectedServices = services,
                TotalCost = totalCost
            };

            await _bookingRepository.AddBookingAsync(booking);

            return booking;
        }

        public decimal CalculateTotalCost(ConferenceRoom room, DateTime startTime, TimeSpan duration, IEnumerable<Service> services)
        {
            var totalHours = duration.TotalHours;
            var baseCost = room.BasePricePerHour * (decimal)totalHours;

            // Calculate discounts/surcharges based on the time of day
            if (startTime.Hour >= 6 && startTime.Hour < 9)
                baseCost *= 0.9m; // 10% discount for morning hours
            else if (startTime.Hour >= 18 && startTime.Hour < 23)
                baseCost *= 0.8m; // 20% discount for evening hours
            else if (startTime.Hour >= 12 && startTime.Hour < 14)
                baseCost *= 1.15m; // 15% surcharge for peak hours

            // Add service costs
            var serviceCost = services.Sum(s => s.Price);

            return baseCost + serviceCost;
        }
    }
}
