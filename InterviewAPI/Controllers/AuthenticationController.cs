using InterviewApi.Models;
using InterviewApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewApi.Controllers
{
    /// <summary>
    /// Handles user authentication and JWT token generation.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;

        private static readonly List<User> Users = new()
        {
            new User { Username = "Seth", Password = "amplifund" },
            new User { Username = "Aaron", Password = "amplifund" },
            new User { Username = "Test", Password = "Test" }
        };
   
        public AuthenticationController(IAuthService authService, IRoleService roleService)
        {
            _authService = authService;
            _roleService = roleService;
        }

        /// <summary>
        /// Authenticates a user and generates a JWT token if the password is correct.
        /// </summary>
        /// <param name="login">The user credentials provided in the request body.</param>
        /// <returns>A JWT token and the assigned role if the credentials are valid; otherwise, an Unauthorized response.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            if (string.IsNullOrWhiteSpace(login.Password) || login.Password != "amplifund")
                return Unauthorized(new { Message = "Invalid password." });

            var randomRole = _roleService.GenerateRandomRole();

            var user = new User
            {
                Username = login.Username,
                Password = login.Password,
                Role = randomRole
            };

            var token = _authService.GenerateJwtToken(user);

            return Ok(new
            {
                user.Username,
                user.Role,
                Token = token,
                Expires = DateTime.UtcNow.AddMinutes(30)
            });
        }
    }
}