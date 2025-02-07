using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineDersPlatformuApi.Models;

namespace OnlineDersPlatformuApi.Services
{
    public class InstructorService
    {
        private readonly IMongoCollection<Instructor> _instructors;

        public InstructorService(IOptions<MongoDbSettings> mongoDbSettings)  // DI
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);   // MongoClient: MongoDB'ye bağlanmak için kullanılan sınıftır. mongoDbSettings.Value.ConnectionString: Veritabanına bağlanmak için kullanılan bağlantı cümlesini alır.
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);  // client.GetDatabase(): MongoDB istemcisi üzerinden belirtilen veritabanına (DatabaseName) bağlanır.

            _instructors = database.GetCollection<Instructor>("Instructors");
        }
        
        public async Task<List<Instructor>> GetAsync() =>
            await _instructors.Find(_ => true).ToListAsync();   // instructors.Find( => true): Instructors koleksiyonundaki tüm belgeleri getirir.  ToListAsync(): Verileri liste şeklinde asenkron bir şekilde döner.


        public async Task<Instructor?> GetAsync(string id) =>
            await _instructors.Find(x => x.Id == id).FirstOrDefaultAsync();  // FirstOrDefaultAsync(): Sadece ilk eşleşen öğeyi döndürür, eğer eşleşen bir öğe yoksa null döner.

        public async Task CreateAsync(Instructor newInstructor) =>
            await _instructors.InsertOneAsync(newInstructor);    // Yeni bir Instructor ekler. InsertOneAsync metodu ile tek bir belge eklenir.

        public async Task UpdateAsync(string id, Instructor updatedInstructor) =>
            await _instructors.ReplaceOneAsync(x => x.Id == id, updatedInstructor);   // ReplaceOneAsync metodu, eşleşen belgeyi tamamen yeni veri ile değiştirir.

        public async Task RemoveAsync(string id) =>
            await _instructors.DeleteOneAsync(x => x.Id == id);   // DeleteOneAsync metodu, eşleşen ilk belgeyi siler.

    }
}
