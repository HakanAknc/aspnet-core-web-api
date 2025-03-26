using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Entities;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestUserController : ControllerBase
    {
        private ITestUserService _testUserService;

        public TestUserController(ITestUserService testUserService)
        {
            _testUserService = testUserService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestUser>>> GetAllTestUser()
        {
            var testUser = await _testUserService.GetAllTestUserAsync();
            return Ok(testUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestUser>> GetTestUserById(string id)
        {
            var testUser = await _testUserService.GetTestUserByIdAsync(id);
            if (testUser == null)
            {
                return NotFound();
            }
            return Ok(testUser);
        }

        [HttpPost]
        public async Task<ActionResult<TestUser>> CreateTestUser(TestUser testUser)
        {
            await _testUserService.CreateTestUserAsync(testUser);
            return CreatedAtAction(nameof(GetTestUserById), new { id = testUser.Id }, testUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TestUser>> UpdateTestUser(string id, TestUser updateTestUser)
        {
            var testUpdate = await _testUserService.GetTestUserByIdAsync(id);
            if (testUpdate == null)
            {
                return NotFound();
            }
            await _testUserService.UpdateTestUserAsync(id, updateTestUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TestUser>> DeleteTestUser(string id)
        {
            var testDelete = await _testUserService.GetTestUserByIdAsync(id);
            if (testDelete == null)
            {
                return NotFound();
            }
            await _testUserService.DeleteTestUserAsync(id);
            return NoContent();
        }
    }
}
