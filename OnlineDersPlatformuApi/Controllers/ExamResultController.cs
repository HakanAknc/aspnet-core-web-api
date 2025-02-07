using Microsoft.AspNetCore.Mvc;
using OnlineDersPlatformuApi.Models;
using OnlineDersPlatformuApi.Services;

namespace OnlineDersPlatformuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamResultController : ControllerBase
    {
        private readonly ExamResultService _resultService;

        public ExamResultController(ExamResultService resultService) =>
            _resultService = resultService;

        [HttpGet]
        public async Task<List<ExamResult>> Get() =>
            await _resultService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(ExamResult newResult)
        {
            await _resultService.CreateAsync(newResult);
            return CreatedAtAction(nameof(Get), new { id = newResult.Id }, newResult);
        }
    }
}
