using Microsoft.AspNetCore.Mvc;
using OnlineDersPlatformuApi.Models;
using OnlineDersPlatformuApi.Services;

namespace OnlineDersPlatformuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseContentController : ControllerBase
    {
        private readonly CourseContentService _contentService;

        public CourseContentController(CourseContentService contentService) =>
            _contentService = contentService;

        [HttpGet]
        public async Task<List<CourseContent>> Get() =>
            await _contentService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<CourseContent>> Get(string id)
        {
            var content = await _contentService.GetAsync(id);

            if (content is null)
            {
                return NotFound();
            }

            return content;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CourseContent newContent)
        {
            await _contentService.CreateAsync(newContent);
            return CreatedAtAction(nameof(Get), new { id = newContent.Id }, newContent);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, CourseContent updatedContent)
        {
            var content = await _contentService.GetAsync(id);

            if (content is null)
            {
                return NotFound();
            }

            updatedContent.Id = content.Id;

            await _contentService.UpdateAsync(id, updatedContent);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var content = await _contentService.GetAsync(id);

            if (content is null)
            {
                return NotFound();
            }

            await _contentService.RemoveAsync(id);

            return NoContent();
        }
    }
}
