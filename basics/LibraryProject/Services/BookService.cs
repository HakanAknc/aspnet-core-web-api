using LibraryProject.Models;
using LibraryProject.Repositories;

namespace LibraryProject.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task CreateBookAsync(Book book) =>
            await _bookRepository.CreateBookAsync(book);

        public async Task DeleteBookAsync(string id) =>
            await _bookRepository.DeleteBookAsync(id);

        public async Task<List<Book>> GetAllBooksAsync() =>
            await _bookRepository.GetAllBooksAsync();

        public async Task<Book> GetBookByIdAsync(string id) =>
            await _bookRepository.GetBookByIdAsync(id);

        public async Task UpdateBookAsync(string id, Book UpdateBook) =>
            await _bookRepository.UpdateBookAsync(id, UpdateBook);
    }
}
