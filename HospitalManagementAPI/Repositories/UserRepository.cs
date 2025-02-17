using HospitalManagementAPI.Models;
using MongoDB.Driver;

namespace HospitalManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("users");
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _users.Find(user => true).ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _users.Find(user =>user.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }
        public async Task UpdateUserAsync(string id, User user)
        {
            await _users.ReplaceOneAsync(u => u.Id == id, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _users.DeleteOneAsync(user => user.Id == id);
        }

        /*
        Bu sınıf, IUserRepository’yi uygular ve MongoDB ile bağlantıyı kurar.
        MongoDB’den kullanıcıları getirir
        Kullanıcı ekler, günceller ve siler
        */

    }
}
