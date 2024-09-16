using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string username, string password, string role);
        Task<string> LoginAsync(string username, string password);
    }
}
