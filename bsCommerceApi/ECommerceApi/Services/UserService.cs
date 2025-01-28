using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync() => await _userRepository.GetAllAsync();

        public async Task<User> GetUserByIdAsync(string id) => await _userRepository.GetByIdAsync(id);

        public async Task CreateUserAsync(User user) => await _userRepository.CreateAsync(user);

        public async Task UpdateUserAsync(string id, User user) => await _userRepository.UpdateAsync(id, user);

        public async Task DeleteUserAsync(string id) => await _userRepository.DeleteAsync(id);

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var users = await _userRepository.GetAllAsync();
            return users.FirstOrDefault(u => u.Username == username);
        }
    }
}
