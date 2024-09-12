namespace Booking_Management.Data.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public List<Service> SelectedServices { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
