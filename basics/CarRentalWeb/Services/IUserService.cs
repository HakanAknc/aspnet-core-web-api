using CarRentalWeb.Models;

namespace CarRentalWeb.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(string id, User updateUser);
        Task DeleteUserAsync(string id);
    }
}
