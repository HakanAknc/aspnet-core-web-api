using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestAPI.Context;
using TestAPI.Entities;

namespace TestAPI.Repositories
{
    public class TestUserRepository : ITestUserRepository
    {
        private readonly IMongoCollection<TestUser> _testUserCollection;

        public TestUserRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _testUserCollection = database.GetCollection<TestUser>(mongoDbSettings.Value.TestUserCollection);
        }

        public async Task CreateTestUserAsync(TestUser testUser) =>
            await _testUserCollection.InsertOneAsync(testUser);

        public async Task DeleteTestUserAsync(string id) =>
            await _testUserCollection.DeleteOneAsync(id);

        public async Task<List<TestUser>> GetAllTestUserAsync() =>
            await _testUserCollection.Find(_ => true).ToListAsync();

        public async Task<TestUser> GetTestUserByIdAsync(string id) =>
            await _testUserCollection.Find(testUser => testUser.Id == id).FirstOrDefaultAsync();

        public async Task UpdateTestUserAsync(string id, TestUser updateTestUser) =>
            await _testUserCollection.ReplaceOneAsync(id, updateTestUser);
    }
}
