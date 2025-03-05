using CarRentalWeb.Models;
using CarRentalWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(string id)
        {
            var cars = await _carService.GetCarByIdAsync(id);
            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(Car car)
        {
            await _carService.CreateCarAsync(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(string id, Car updateCar)
        {
            var carsUpdate = await _carService.GetCarByIdAsync(id);
            if (carsUpdate == null)
            {
                return NotFound();
            }

            await _carService.UpdateCarAsync(id, updateCar);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            var carsDelete = await _carService.GetCarByIdAsync(id);
            if (carsDelete == null)
            {
                return NotFound();
            }

            await _carService.DeleteCarAsync(id);
            return NoContent();
        }
    }
}
