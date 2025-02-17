using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(string id, User user);
        Task DeleteUserAsync(string id);

        /*
         Tüm kullanıcıları getir
         Belirli bir kullanıcıyı ID ile getir
         Yeni bir kullanıcı oluştur
         Var olan bir kullanıcıyı güncelle
         Bir kullanıcıyı sil
         */
    }
}
