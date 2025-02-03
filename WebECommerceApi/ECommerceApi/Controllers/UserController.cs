using ECommerceApi.DTOs;
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            // Şifreleri dışarıya açmadan kullanıcıları DTO'ya dönüştür
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                WalletBalance = user.WalletBalance
            }).ToList();

            return Ok(userDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userService.CreateUserAsync(user);

            // Kullanıcı dönüşünde şifreyi gizlemek için UserDto oluştur
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                WalletBalance = user.WalletBalance
            };

            return CreatedAtAction(nameof(GetAllUsers), new { id = userDto.Id }, userDto);
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
