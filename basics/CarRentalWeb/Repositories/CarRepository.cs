using CarRentalWeb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalWeb.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoCollection<Car> _carsCollection;

        public CarRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _carsCollection = database.GetCollection<Car>(mongoDbSettings.Value.CarCollection);
        }
        public async Task<List<Car>> GetAllCarsAsync() =>
            await _carsCollection.Find(_ => true).ToListAsync();

        public async Task<Car> GetCarByIdAsync(string id) =>
            await _carsCollection.Find(car => car.Id == id).FirstOrDefaultAsync();

        public async Task CreateCarAsync(Car car) =>
            await _carsCollection.InsertOneAsync(car);

        public async Task UpdateCarAsync(string id, Car updatedCar) =>
            await _carsCollection.ReplaceOneAsync(car => car.Id == id, updatedCar);

        public async Task DeleteCarAsync(string id) =>
            await _carsCollection.DeleteOneAsync(car => car.Id == id);
    }
}
