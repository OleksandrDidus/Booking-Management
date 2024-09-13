using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IUserService
    {
        Task<User> AuthenticateUserAsync(string username, string password);
        Task RegisterUserAsync(User user);
    }
}
