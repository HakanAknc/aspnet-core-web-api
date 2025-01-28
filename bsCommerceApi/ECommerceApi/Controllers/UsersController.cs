using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Models;
using ECommerceApi.Services;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var existingUser = await _userService.GetUserByUsernameAsync(user.Username);
            if (existingUser != null)
                return Conflict(new { message = "Username already exists." });

            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var existingUser = await _userService.GetUserByUsernameAsync(user.Username);

            if (existingUser == null || existingUser.Password != user.Password)
                return Unauthorized(new { message = "Invalid username or password." });

            var tokenService = new TokenService(HttpContext.RequestServices.GetRequiredService<IConfiguration>());
            var token = tokenService.GenerateToken(existingUser.Username, existingUser.Role);

            return Ok(new { token });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            await _userService.UpdateUserAsync(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
