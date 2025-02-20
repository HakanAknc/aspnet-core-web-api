using LibraryProject.Models;

namespace LibraryProject.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(string id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(string id, Book UpdateBook);
        Task DeleteBookAsync(string id);
    }
}
