using TestAPI.Entities;
using TestAPI.Repositories;

namespace TestAPI.Services
{
    public class TestUserService : ITestUserService
    {
        private readonly ITestUserRepository _testUserRepository;

        public TestUserService(ITestUserRepository testUserRepository)
        {
            _testUserRepository = testUserRepository;
        }

        public async Task CreateTestUserAsync(TestUser testUser) =>
            await _testUserRepository.CreateTestUserAsync(testUser);

        public async Task DeleteTestUserAsync(string id) =>
            await _testUserRepository.DeleteTestUserAsync(id);

        public async Task<List<TestUser>> GetAllTestUserAsync() =>
            await _testUserRepository.GetAllTestUserAsync();

        public async Task<TestUser> GetTestUserByIdAsync(string id) =>
            await _testUserRepository.GetTestUserByIdAsync(id);

        public async Task UpdateTestUserAsync(string id, TestUser updateTestUser) =>
            await _testUserRepository.UpdateTestUserAsync(id, updateTestUser);
    }
}
