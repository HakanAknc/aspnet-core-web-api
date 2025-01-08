using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        // Geçici olarak bellekte görevleri tutacak liste
        private static List<TodoItem> _todoList = new List<TodoItem>();
        private static int _idCounter = 1; // Benzersiz ID için sayaç

        // 1. Görevleri Listeleme (GET)
        [HttpGet]
        public IActionResult GetAllTodos()
        {
            return Ok(_todoList); // 200 OK yanıtı ile görevleri döndür
        }

        // 2. Görev Ekleme (POST)
        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoItem newTodo)
        {
            if (string.IsNullOrWhiteSpace(newTodo.Title))
            {
                return BadRequest("Görev başlığı boş olamaz!"); // 400 Hatası
            }

            newTodo.Id = _idCounter++; // Benzersiz ID atama
            _todoList.Add(newTodo); // Görevi listeye ekle

            return CreatedAtAction(nameof(GetAllTodos), new { id = newTodo.Id }, newTodo); // 201 Yanıtı
        }

        // 3. Görev Silme (DELETE)
        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == id);   // ID ile görevi bul
            if (todo == null)
            {
                return NotFound($"ID {id} için görev bulunamadı!");  // 404 Hatası
            }

            _todoList.Remove(todo);   // Görevi listeden kaldır
            return NoContent();   // 204 Yanıtı
        }

        // 4. Görev Güncelleme (PUT)
        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, [FromBody] TodoItem updatedTodo)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == id);   // ID ile görevi bul
            if (todo == null)
            {
                return NotFound($"ID {id} için görev bulunmadı!");   // 404 Hatası
            }

            if (string.IsNullOrWhiteSpace(updatedTodo.Title))
            {
                return BadRequest("Görev başlığı boş olamaz!");
            }

            // Görevi güncelle
            todo.Title = updatedTodo.Title;
            todo.IsCompleted = updatedTodo.IsCompleted;

            return Ok(todo);   // 200 Yanıtı

        } 
    } 
}
