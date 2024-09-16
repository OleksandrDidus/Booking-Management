namespace Booking_Management.Data.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int ConferenceRoomId { get; set; }
        public ConferenceRoom ConferenceRoom { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public IEnumerable<Service> SelectedServices { get; set; }

        public decimal TotalCost { get; set; }
    }
}
