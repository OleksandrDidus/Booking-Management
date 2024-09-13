using Booking_Management.Data.Model;
using Booking_Management.Data;
using Booking_Management.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking_Management.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username) =>
            await _context.Users.SingleOrDefaultAsync(u => u.Username == username);

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
