namespace Booking_Management.Data.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BasePricePerHour { get; set; }
        public List<Service> Services { get; set; }
    }
}
