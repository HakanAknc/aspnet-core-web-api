using Microsoft.AspNetCore.Mvc;
using TodoApiWithMongoDb.Models;
using TodoApiWithMongoDb.Services;

namespace TodoApiWithMongoDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService) =>
            _todoService = todoService;

        [HttpGet]
        public async Task<List<Todo>> Get() =>
            await _todoService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Todo>> Get(string id)
        {
            var todo = await _todoService.GetAsync(id);

            if (todo is null)
            {
                return NotFound();
            }

            return todo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Todo newTodo)
        {
            await _todoService.CreateAsync(newTodo);

            return CreatedAtAction(nameof(Get), new { id = newTodo.Id }, newTodo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Todo updatedTodo)
        {
            var todo = await _todoService.GetAsync(id);

            if (todo is null)
            {
                return NotFound();
            }

            updatedTodo.Id = todo.Id;

            await _todoService.UpdateAsync(id, updatedTodo);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var todo = await _todoService.GetAsync(id);

            if (todo is null)
            {
                return NotFound();
            }

            await _todoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
