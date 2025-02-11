using CarRentalApi.DataAccess;
using CarRentalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            var users = await _userRepository.GetAllUserAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userRepository.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetAllUser), new { id = user.Id}, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, User updatedUser)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userRepository.UpdateUserAsync(id, updatedUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if ( existingUser == null)
            {
                return NotFound();
            }
            await _userRepository.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
