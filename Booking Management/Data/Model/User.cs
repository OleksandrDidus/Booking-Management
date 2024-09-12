namespace Booking_Management.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }  // Хеш пароля
        public string Role { get; set; }  // Роль користувача (Admin/User)
    }

}
