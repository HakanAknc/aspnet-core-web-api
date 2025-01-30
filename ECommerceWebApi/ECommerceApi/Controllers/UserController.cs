using ECommerceApi.Models;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // Tüm kullanıcıları listele
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // Yeni kullanıcı ekle
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
        }

        // Kullanıcı güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, User user)
        {
            await _userService.UpdateUserAsync(id, user);
            return NoContent();
        }

        // Kullanıcı sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
