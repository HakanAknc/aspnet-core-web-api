using CarRentalApi.DataAccess;
using CarRentalApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _carRepository;

        public CarController(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllCars()
        {
            var cars = await _carRepository.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(string id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(Car car)
        {
            await _carRepository.CreateCarAsync(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(string id, Car updatedCar)
        {
            var existingCar = await _carRepository.GetCarByIdAsync(id);
            if (existingCar == null)
            {
                return NotFound();
            }
            await _carRepository.UpdateCarAsync(id, updatedCar);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar(string id)
        {
            var existingCar = await _carRepository.GetCarByIdAsync(id);
            if ( existingCar == null)
            {
                return NotFound();
            }
            await _carRepository.DeleteCarAsync(id);
            return NoContent();
        }
    }
}
