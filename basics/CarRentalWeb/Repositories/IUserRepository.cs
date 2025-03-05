using CarRentalWeb.Models;

namespace CarRentalWeb.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(string id, User updateUser);
        Task DeleteUserAsync(string id);
    }
}
