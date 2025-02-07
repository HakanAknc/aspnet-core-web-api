using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDersPlatformuApi.Models;
using OnlineDersPlatformuApi.Services;

namespace OnlineDersPlatformuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService) => 
            _courseService = courseService;

        [HttpGet]
        public async Task<List<Course>> Get() =>
            await _courseService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Course>> Get(string id)
        {
            var course = await _courseService.GetAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Course newCourse)
        {
            await _courseService.CreateAsync(newCourse);
            return CreatedAtAction(nameof(Get), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Course updatedCourse)
        {
            var course = await _courseService.GetAsync(id);

            if ( course == null)
            {
                return NotFound();
            }

            updatedCourse.Id = course.Id;

            await _courseService.UpdateAsync(id, updatedCourse);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var course = _courseService.GetAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            await _courseService.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("{courseId:length(24)}/add-student/{studentId:length(24)}")]
        public async Task<IActionResult> AddStudentToCourse(string courseId, string studentId)
        {
            var course = await _courseService.GetAsync(courseId);

            if (course is null)
            {
                return NotFound("Ders bulunamadı.");
            }

            if (!course.StudentIds.Contains(studentId))
            {
                course.StudentIds.Add(studentId);
                await _courseService.UpdateAsync(courseId, course);
            }

            return Ok("Öğrenci başarıyla eklendi.");
        }

        [HttpPost("{courseId:length(24)}/add-instructor/{instructorId:length(24)}")]
        public async Task<IActionResult> AddInstructorToCourse(string courseId, string instructorId)
        {
            var course = await _courseService.GetAsync(courseId);

            if (course is null)
            {
                return NotFound("Ders bulunamadı.");
            }

            course.InstructorId = instructorId;
            await _courseService.UpdateAsync(courseId, course);

            return Ok("Eğitmen başarıyla eklendi.");
        }

    }
}
