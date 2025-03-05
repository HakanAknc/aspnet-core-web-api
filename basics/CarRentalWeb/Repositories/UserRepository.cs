using CarRentalWeb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalWeb.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _userCollection = database.GetCollection<User>(mongoDbSettings.Value.UserCollection);
        }

        public async Task CreateUserAsync(User user) =>
            await _userCollection.InsertOneAsync(user);

        public async Task DeleteUserAsync(string id) =>
            await _userCollection.DeleteOneAsync(user => user.Id == id);

        public async Task<List<User>> GetAllUsersAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User> GetUserByIdAsync(string id) =>
            await _userCollection.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task UpdateUserAsync(string id, User updateUser) =>
            await _userCollection.ReplaceOneAsync(user => user.Id == id, updateUser);
    }
}
