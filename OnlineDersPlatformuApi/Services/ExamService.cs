using MongoDB.Driver;
using OnlineDersPlatformuApi.Models;
using Microsoft.Extensions.Options;

namespace OnlineDersPlatformuApi.Services
{
    public class ExamService
    {
        private readonly IMongoCollection<Exam> _exams;

        public ExamService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _exams = database.GetCollection<Exam>("Exams");
        }

        public async Task<List<Exam>> GetAsync() =>
            await _exams.Find(_ => true).ToListAsync();

        public async Task<Exam?> GetAsync(string id) =>
            await _exams.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Exam newExam) =>
            await _exams.InsertOneAsync(newExam);

        public async Task UpdateAsync(string id, Exam updatedExam) =>
            await _exams.ReplaceOneAsync(x => x.Id == id, updatedExam);

        public async Task RemoveAsync(string id) =>
            await _exams.DeleteOneAsync(x => x.Id == id);
    }
}
