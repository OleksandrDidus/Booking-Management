using Booking_Management.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password, string role)
        {
            var token = await _authService.RegisterAsync(username, password, role);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _authService.LoginAsync(username, password);
            Response.Cookies.Append("jwt", token);
            return Ok(new { token });
        }
    }
}
