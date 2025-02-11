using CarRentalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalApi.DataAccess
{
    public class ReservationRepository
    {
        private readonly IMongoCollection<Reservation> _reservationCollection;

        public ReservationRepository(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _reservationCollection = database.GetCollection<Reservation>("reservations");
        }

        public async Task<List<Reservation>> GetAllReservationAsync() =>
            await _reservationCollection.Find(_ => true).ToListAsync();

        public async Task<Reservation?> GetReservationByIdAsync(string id) =>
            await _reservationCollection.Find(reservation => reservation.Id == id).FirstOrDefaultAsync();

        public async Task CreateReservationAsync(Reservation newReservation) =>
            await _reservationCollection.InsertOneAsync(newReservation);

        public async Task UpdateReservationAsync(string id, Reservation updatedReservation) =>
            await _reservationCollection.ReplaceOneAsync(reservation => reservation.Id == id, updatedReservation);

        public async Task DeleteReservationAsync(string id) =>
            await _reservationCollection.DeleteOneAsync(reservation => reservation.Id == id);
    }
}
