using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user);
    }

}
