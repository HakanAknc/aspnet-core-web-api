using CarRentalWeb.Models;
using CarRentalWeb.Repositories;

namespace CarRentalWeb.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User user) =>
            await _userRepository.CreateUserAsync(user);

        public async Task DeleteUserAsync(string id) =>
            await _userRepository.DeleteUserAsync(id);

        public async Task<List<User>> GetAllUsersAsync() =>
            await _userRepository.GetAllUsersAsync();

        public async Task<User> GetUserByIdAsync(string id) =>
            await _userRepository.GetUserByIdAsync(id);

        public async Task UpdateUserAsync(string id, User updateUser) =>
            await _userRepository.UpdateUserAsync(id, updateUser);
    }
}
