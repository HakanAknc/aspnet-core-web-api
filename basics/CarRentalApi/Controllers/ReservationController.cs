using CarRentalApi.DTOs;
using CarRentalApi.Models;
using CarRentalApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservation = await _reservationService.GetAllReservationAsync();
            var reservationDtos = reservation.Select(reservation => new ReservationDTO
            {
                Id = reservation.Id,
                CarId = reservation.CarId,
                CustomerId = reservation.CustomerId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                Status = reservation.Status
            }).ToList();

            return Ok(reservationDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationDto createReservationDto)
        {
            var reservation = new Reservation
            {
                CarId = createReservationDto.CarId,
                CustomerId = createReservationDto.CustomerId,
                StartDate = createReservationDto.StartDate,
                EndDate = createReservationDto.EndDate,
                Status = "Active",  // Başlangıçta aktif
            };

            await _reservationService.CreateReservationAsync(reservation);

            var reservationDto = new ReservationDTO
            {
                Id = reservation.Id,
                CarId = reservation.CarId,
                CustomerId = reservation.CustomerId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                Status = reservation.Status
            };

            return CreatedAtAction(nameof(GetAll), new { id = reservation.Id }, reservationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Reservation updatedReservation)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null) return NotFound();

            var reservationDto = new ReservationDTO
            {
                Id = reservation.Id,
                CarId = reservation.CarId,
                CustomerId = reservation.CustomerId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                Status = reservation.Status
            };

            return Ok(reservationDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var reservation = await _reservationService.DeleteReservationAsync(id);
            if (!reservation) return NotFound();
            return NoContent();
        }
    }
}
