using MongoDB.Driver;
using OnlineDersPlatformuApi.Models;
using Microsoft.Extensions.Options;

namespace OnlineDersPlatformuApi.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _students = database.GetCollection<Student>("Students");
        }

        public async Task<List<Student>> GetAsync() =>
            await _students.Find(_ => true).ToListAsync();

        public async Task<Student?> GetAsync(string id) =>
            await _students.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Student newStudent) =>
            await _students.InsertOneAsync(newStudent);

        public async Task UpdateAsync(string id, Student updatedStudent) =>
            await _students.ReplaceOneAsync(x => x.Id == id, updatedStudent);

        public async Task RemoveAsync(string id) =>
            await _students.DeleteOneAsync(x => x.Id == id);
    }
}
