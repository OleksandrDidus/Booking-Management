namespace Booking_Management.Data.Model
{
    public class BookingConfirmation
    {
        public int RoomId { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TotalCost { get; set; }
    }

}
