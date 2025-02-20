using LibraryProject.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BookRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _booksCollection = database.GetCollection<Book>("books");
        }

        public async Task CreateBookAsync(Book book) =>
            await _booksCollection.InsertOneAsync(book);

        public async Task DeleteBookAsync(string id) =>
            await _booksCollection.DeleteOneAsync(book => book.Id == id);

        public async Task<List<Book>> GetAllBooksAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book> GetBookByIdAsync(string id) =>
            await _booksCollection.Find(book => book.Id == id).FirstOrDefaultAsync();

        public async Task UpdateBookAsync(string id, Book UpdateBook) =>
            await _booksCollection.ReplaceOneAsync(book => book.Id == id, UpdateBook);
    }
}
