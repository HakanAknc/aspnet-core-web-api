using CarRentalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalApi.Repositories
{
    public class ReservationRepository
    {
        private readonly IMongoCollection<Reservation> _reservationCollection;

        public ReservationRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _reservationCollection = mongoDatabase.GetCollection<Reservation>("reservations");
        }

        public async Task<List<Reservation>> GetAllAsync() =>
            await _reservationCollection.Find(_ => true).ToListAsync();

        public async Task<Reservation> GetByIdAsync(string id) =>
            await _reservationCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Reservation reservation) =>
            await _reservationCollection.InsertOneAsync(reservation);

        public async Task UpdateAsync(string id, Reservation updatedReservation) =>
            await _reservationCollection.ReplaceOneAsync(x => x.Id == id, updatedReservation);

        public async Task DeleteAsync(string id) =>
            await _reservationCollection.DeleteOneAsync(x => x.Id == id);

    }
}
