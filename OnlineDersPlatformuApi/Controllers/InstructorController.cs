using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDersPlatformuApi.Models;
using OnlineDersPlatformuApi.Services;

namespace OnlineDersPlatformuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorService _instructorService;

        public InstructorController(InstructorService instructorService) =>
            _instructorService = instructorService;

        [HttpGet]
        public async Task<List<Instructor>> Get() =>    // Bu yöntem, tüm eğitmenleri listelemek için kullanılır.
            await _instructorService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Instructor>> Get(string id)
        {
            var instructor = await _instructorService.GetAsync(id);

            if (instructor is null)
            {
                return NotFound();
            }

            return instructor;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Instructor newInstructor)
        {
            await _instructorService.CreateAsync(newInstructor);
            return CreatedAtAction(nameof(Get), new { id = newInstructor.Id }, newInstructor);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Instructor updatedInstructor)
        {
            var instructor = await _instructorService.GetAsync(id);

            if (instructor is null)
            {
                return NotFound();
            }

            updatedInstructor.Id = instructor.Id;
            await _instructorService.UpdateAsync(id, updatedInstructor);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var instructor = await _instructorService.GetAsync(id);

            if (instructor is null)
            {
                return NotFound();
            }

            await _instructorService.RemoveAsync(id);
            return NoContent();
        }
    }
}
