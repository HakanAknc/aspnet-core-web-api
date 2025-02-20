using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var cars = await _bookService.GetAllBooksAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            var cars = await _bookService.GetBookByIdAsync(id);
            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            await _bookService.CreateBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(string id, [FromBody] Book updateBook)
        {
            var booksUpdate = await _bookService.GetBookByIdAsync(id);
            if (booksUpdate == null)
            {
                return NotFound();
            }
            await _bookService.UpdateBookAsync(id, updateBook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var booksDelete = await _bookService.GetBookByIdAsync(id);
            if (booksDelete == null)
            {
                return NotFound();
            }
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
