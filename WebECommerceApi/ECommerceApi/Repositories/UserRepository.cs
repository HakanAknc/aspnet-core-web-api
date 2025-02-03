using ECommerceApi.Models;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;   // Burada Dependency Injection (DI) tanımlanmış
                                                                    // redonly tanımı yapıldı ise bunun değeri iki yerde tanımlanabilir "Constructar ve Tanımlandığı yer"
        public UserRepository(IMongoDatabase database)
        {
            _usersCollection = database.GetCollection<User>("Users");
        }

        // CRUD
        // Tüm kullanıcıları listele metodu
        // Read
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        // Kullanıcı ekleme metodu
        // Create
        public async Task CreateUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        // Kullanıcıyı güncelleme metodu
        // Update
        public async Task UpdateUserAsync(string id, User updatedUser)
        {
            await _usersCollection.ReplaceOneAsync(u => u.Id == id, updatedUser);
        }

        // Kullanıcıyı silme metodu
        // Delete
        public async Task DeleteUserAsync(string id)
        {
            await _usersCollection.DeleteOneAsync(u => u.Id == id);
        }
    }
}
