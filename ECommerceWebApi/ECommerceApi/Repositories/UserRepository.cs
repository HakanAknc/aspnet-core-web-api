using ECommerceApi.Models;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserRepository(IMongoDatabase database)
        {
            _usersCollection = database.GetCollection<User>("Users");
        }

        // Tüm kullanıcıları listele
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        // Kullanıcı ekle
        public async Task CreateUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        // Kullanıcı güncelle
        public async Task UpdateUserAsync(string id, User updatedUser)
        {
            await _usersCollection.ReplaceOneAsync(u => u.Id == id, updatedUser);
        }

        // Kullanıcı sil
        public async Task DeleteUserAsync(string id)
        {
            await _usersCollection.DeleteOneAsync(u => u.Id == id);
        }
    }
}
