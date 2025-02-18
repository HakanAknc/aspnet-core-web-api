using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CarProject.DTOs;
using CarProject.Models;
using CarProject.Services;

namespace CarProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        // Create a new car
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CarDTO.CreateCarDto carDto)
        {
            if (carDto == null)
            {
                return BadRequest("Invalid car data.");
            }

            var car = _mapper.Map<Car>(carDto);
            car.CreateTime = DateTime.UtcNow;
            car.ModifyTime = DateTime.UtcNow;
            car.IsActive = false;

            await _carService.CreateCarAsync(car);

            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, _mapper.Map<CarDTO.GetCarDto>(car));
        }

        // Get car by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(string id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound($"Car with id {id} not found.");
            }

            return Ok(_mapper.Map<CarDTO.GetCarDto>(car));
        }

        // Get all cars
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            var carDtos = _mapper.Map<List<CarDTO.GetCarDto>>(cars);

            return Ok(carDtos);
        }

        // Update car
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(string id, [FromBody] CarDTO.UpdateCarDto carDto)
        {
            if (carDto == null)
            {
                return BadRequest("Invalid car data.");
            }

            var existingCar = await _carService.GetCarByIdAsync(id);
            if (existingCar == null)
            {
                return NotFound($"Car with id {id} not found.");
            }

            var updatedCar = _mapper.Map(carDto, existingCar);
            updatedCar.ModifyTime = DateTime.UtcNow;

            await _carService.UpdateCarAsync(id, updatedCar);

            return Ok(_mapper.Map<CarDTO.GetCarDto>(updatedCar));
        }

        // Delete car
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound($"Car with id {id} not found.");
            }

            await _carService.DeleteCarAsync(id);

            return NoContent(); // Success, no content returned
        }
    }
}
