using CarRentalApi.Models;
using CarRentalApi.Repositories;

namespace CarRentalApi.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<Reservation>> GetAllReservationAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(string id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task<bool> UpdateReservationAsync(string id, Reservation updatedReservation)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation is null)
            {
                return false;
            }
            updatedReservation.Id = id;
            await _reservationRepository.UpdateAsync(id, updatedReservation);
            return true;
        }

        public async Task<bool> DeleteReservationAsync(string id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation is null) return false;

            await _reservationRepository.DeleteAsync(id);
            return true;
        }

    }
}
