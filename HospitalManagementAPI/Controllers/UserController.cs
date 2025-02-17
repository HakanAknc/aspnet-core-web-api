using HospitalManagementAPI.Models;
using HospitalManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var users = await _userService.GetUserByIdAsync(id);
            if (users == null)
                return NotFound("Kullanıcı bulunamadı.");

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Geçersiz kullanıcı bilgileri.");

            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest("Geçersiz kullanıcı bilgileri.");

            await _userService.UpdateUserAsync(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        /*
         Tüm kullanıcıları getirir → GET /api/users
         ID’ye göre kullanıcı getirir → GET /api/users/{id}
         Yeni kullanıcı ekler → POST /api/users
         Mevcut kullanıcıyı günceller → PUT /api/users/{id}
         Kullanıcıyı siler → DELETE /api/users/{id}
         */
    }
}
