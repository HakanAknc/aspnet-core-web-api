using TestAPI.Entities;

namespace TestAPI.Repositories
{
    public interface ITestUserRepository
    {
        Task<List<TestUser>> GetAllTestUserAsync();
        Task<TestUser> GetTestUserByIdAsync(string id);
        Task CreateTestUserAsync(TestUser testUser);
        Task UpdateTestUserAsync(string id, TestUser updateTestUser);
        Task DeleteTestUserAsync(string id);
    }
}
