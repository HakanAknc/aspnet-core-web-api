using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _usersCollection = database.GetCollection<User>("users");
        }

        public async Task<List<User>> GetAllUsersAsync() =>
            await _usersCollection.Find(user => true).ToListAsync();

        public async Task<User> GetUserByIdAsync(string id) =>
            await _usersCollection.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task CreateUserAsync(User user) =>
            await _usersCollection.InsertOneAsync(user);

        public async Task UpdateUserAsync(string id, User updatedUser) =>
            await _usersCollection.ReplaceOneAsync(user => user.Id == id, updatedUser);

        public async Task DeletUserAsync(string id) =>
            await _usersCollection.DeleteOneAsync(user => user.Id == id);
    }
}
