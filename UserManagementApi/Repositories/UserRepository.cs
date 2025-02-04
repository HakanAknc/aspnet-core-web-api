using MongoDB.Driver;
using UserManagementApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace UserManagementApi.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDbConnection"));
            var database = client.GetDatabase("UserDb");
            _users = database.GetCollection<User>("Users");
        }

        public List<User> GetAllUsers()
        {
            return _users.Find(user => true).ToList();
        }

        public User GetUserById(string id)
        {
            return _users.Find<User>(user => user.Id == new ObjectId(id)).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            _users.InsertOne(user);
        }

        public void UpdateUser(string id, User userIn)
        {
            _users.ReplaceOne(user => user.Id == new ObjectId(id), userIn);
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user.Id == new ObjectId(id));
        }
    }
}
