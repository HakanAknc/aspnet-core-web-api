using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineDersPlatformuApi.Models;

namespace OnlineDersPlatformuApi.Services
{
    public class CourseContentService
    {
        private readonly IMongoCollection<CourseContent> _courseContents;
        public CourseContentService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _courseContents = database.GetCollection<CourseContent>("CourseContents");

        }

        public async Task<List<CourseContent>> GetAsync() =>
            await _courseContents.Find(_ => true).ToListAsync();

        public async Task<CourseContent?> GetAsync(string id) =>
            await _courseContents.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(CourseContent newContent) =>
            await _courseContents.InsertOneAsync(newContent);

        public async Task UpdateAsync(string id, CourseContent updatedContent) =>
            await _courseContents.ReplaceOneAsync(id, updatedContent);

        public async Task RemoveAsync(string id) =>
            await _courseContents.DeleteOneAsync(x => x.Id == id);
    }
}
