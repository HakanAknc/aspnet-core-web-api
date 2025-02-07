using MongoDB.Driver;
using OnlineDersPlatformuApi.Models;
using Microsoft.Extensions.Options;

namespace OnlineDersPlatformuApi.Services
{
    public class ExamResultService
    {
        private readonly IMongoCollection<ExamResult> _examResults;

        public ExamResultService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _examResults = database.GetCollection<ExamResult>("ExamResults");
        }

        public async Task<List<ExamResult>> GetAsync() =>
            await _examResults.Find(_ => true).ToListAsync();

        public async Task<ExamResult?> GetAsync(string id) =>
            await _examResults.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ExamResult newResult) =>
            await _examResults.InsertOneAsync(newResult);

        public async Task UpdateAsync(string id, ExamResult updatedResult) =>
            await _examResults.ReplaceOneAsync(x => x.Id == id, updatedResult);

        public async Task RemoveAsync(string id) =>
            await _examResults.DeleteOneAsync(x => x.Id == id);
    }
}
