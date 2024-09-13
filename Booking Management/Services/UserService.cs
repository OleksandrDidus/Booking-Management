using Booking_Management.Data.Model;
using Booking_Management.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Booking_Management.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user != null && _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success)
            {
                return user;
            }
            return null;
        }

        public async Task RegisterUserAsync(User user)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);
            await _userRepository.AddUserAsync(user);
        }
    }
}
