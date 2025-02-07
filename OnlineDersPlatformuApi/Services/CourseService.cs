using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineDersPlatformuApi.Models;

namespace OnlineDersPlatformuApi.Services
{
    public class CourseService
    {
        private readonly IMongoCollection<Course> _courses;

        public CourseService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _courses = database.GetCollection<Course>("Course");
        }

        public async Task<List<Course>> GetAsync() =>
            await _courses.Find(_ =>  true).ToListAsync();

        public async Task<Course?> GetAsync(string id) =>
            await _courses.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Course newCourse) =>
            await _courses.InsertOneAsync(newCourse);

        public async Task UpdateAsync(string id, Course updatedCourse) =>
            await _courses.ReplaceOneAsync(x => x.Id == id, updatedCourse);

        public async Task RemoveAsync(string id) =>
            await _courses.DeleteOneAsync(x => x.Id == id);
    }
}
