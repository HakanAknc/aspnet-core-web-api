using CarRentalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalApi.DataAccess
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _userCollection = database.GetCollection<User>("users");
        }

        public async Task<List<User>> GetAllUserAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetUserByIdAsync(string id) =>
            await _userCollection.Find(User => User.Id == id).FirstOrDefaultAsync();

        public async Task CreateUserAsync(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateUserAsync(string id, User updatedUser) =>
            await _userCollection.ReplaceOneAsync(user => user.Id == id, updatedUser);

        public async Task DeleteUserAsync(string id) =>
            await _userCollection.DeleteOneAsync(user => user.Id == id);
    }
}
