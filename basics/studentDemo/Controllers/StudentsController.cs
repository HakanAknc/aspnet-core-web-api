using Microsoft.AspNetCore.Mvc;
using studentDemo.Data;
using studentDemo.Models;

namespace studentDemo.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // 1. Tüm öğrencileri listele (GET)
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(ApplicationContext.Students);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneStudent([FromRoute(Name = "id")] int id)
        {
            var student = ApplicationContext
                .Students
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            if (student is null)
            {
                return NotFound(); //404
            }

            return Ok(student);
        }

        // 2. Tek bir öğrenci ekle (POST)
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            // Yeni öğrenciye benzersiz bir ID ver
            student.Id = ApplicationContext.Students.Max(s => s.Id) + 1;

            // Listeye ekle
            ApplicationContext.Students.Add(student);

            return CreatedAtAction(nameof(GetAllStudents), student);
        }

        // 3. Öğrenciyi güncelle (PUT)
        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = ApplicationContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404: Öğrenci bulunamadı

            // Güncelle
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Section = updatedStudent.Section;

            return Ok(student); // 200: Güncellenmiş öğrenci döndür
        }

        // 4. Öğrenciyi sil (DELETE)
        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = ApplicationContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404: Öğrenci bulunamadı

            // Listeden sil
            ApplicationContext.Students.Remove(student);

            return NoContent(); // 204: Silme başarılı ama içerik yok
        }
    }
}
