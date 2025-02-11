using CarRentalApi.DataAccess;
using CarRentalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationController(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> GetAllReservation()
        {
            var reservations = await _reservationRepository.GetAllReservationAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationById(string id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            await _reservationRepository.CreateReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(string id, Reservation updatedReservation)
        {
            var existingReservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (existingReservation == null)
            {
                return NotFound();
            }
            await _reservationRepository.UpdateReservationAsync(id, updatedReservation);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            var existingReservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (existingReservation == null)
            {
                return NotFound();
            }
            await _reservationRepository.DeleteReservationAsync(id);
            return NoContent();
        }
    }
}
