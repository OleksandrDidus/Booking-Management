using System.Text.Json.Serialization;

namespace Booking_Management.Data.Model
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ConferenceRoomId { get; set; }
        [JsonIgnore]
        public ConferenceRoom ?ConferenceRoom { get; set; }
    }
}
