using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;         // Dependency Injection (DI)

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetAllUsersAsync() => _userRepository.GetAllUsersAsync();

        public Task CreateUserAsync(User user) => _userRepository.CreateUserAsync(user);

        public Task UpdateUserAsync(string id, User user) => _userRepository.UpdateUserAsync(id, user);

        public Task DeleteUserAsync(string id) => _userRepository.DeleteUserAsync(id);
    }
}
