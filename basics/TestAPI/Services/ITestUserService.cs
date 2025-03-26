using TestAPI.Entities;

namespace TestAPI.Services
{
    public interface ITestUserService
    {
        Task<List<TestUser>> GetAllTestUserAsync();
        Task<TestUser> GetTestUserByIdAsync(string id);
        Task CreateTestUserAsync(TestUser testUser);
        Task UpdateTestUserAsync(string id, TestUser updateTestUser);
        Task DeleteTestUserAsync(string id);
    }
}
