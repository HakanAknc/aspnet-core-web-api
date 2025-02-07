using Microsoft.AspNetCore.Mvc;
using OnlineDersPlatformuApi.Models;
using OnlineDersPlatformuApi.Services;

namespace OnlineDersPlatformuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly ExamService _examService;

        public ExamController(ExamService examService) =>
            _examService = examService;

        [HttpGet]
        public async Task<List<Exam>> Get() =>
            await _examService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Exam>> Get(string id)
        {
            var exam = await _examService.GetAsync(id);

            if (exam is null)
            {
                return NotFound();
            }

            return exam;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Exam newExam)
        {
            await _examService.CreateAsync(newExam);
            return CreatedAtAction(nameof(Get), new { id = newExam.Id }, newExam);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Exam updatedExam)
        {
            var exam = await _examService.GetAsync(id);

            if (exam is null)
            {
                return NotFound();
            }

            updatedExam.Id = exam.Id;

            await _examService.UpdateAsync(id, updatedExam);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var exam = await _examService.GetAsync(id);

            if (exam is null)
            {
                return NotFound();
            }

            await _examService.RemoveAsync(id);

            return NoContent();
        }
    }
}
