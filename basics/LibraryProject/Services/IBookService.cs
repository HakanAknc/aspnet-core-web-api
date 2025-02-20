using LibraryProject.Models;

namespace LibraryProject.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(string id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(string id, Book UpdateBook);
        Task DeleteBookAsync(string id);
    }
}
