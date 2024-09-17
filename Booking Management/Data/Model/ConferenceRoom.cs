namespace Booking_Management.Data.Model
{
    public class ConferenceRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BasePricePerHour { get; set; }

        // List of services offered in the room
        public ICollection<Service> ?Services { get; set; }
    }
}
