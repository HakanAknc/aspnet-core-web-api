using CarRentalApi.DataAccess;
using CarRentalApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly PricingRepository _pricingRepository;

        public PricingController(PricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pricing>>> GetAllPricing()
        {
            var pricings = await _pricingRepository.GetAllPricingAsync();
            return Ok(pricings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pricing>> GetPricingById(string id)
        {
            var pricing = await _pricingRepository.GetPricingByIdAsync(id);
            if (pricing == null)
            {
                return NotFound();
            }
            return Ok(pricing);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(Pricing pricing)
        {
            await _pricingRepository.CreatePricingAsync(pricing);
            return CreatedAtAction(nameof(GetPricingById), new { id = pricing.Id }, pricing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePricing(string id, Pricing updatePricing)
        {
            var existingPricing = await _pricingRepository.GetPricingByIdAsync(id);
            if (existingPricing == null)
            {
                return NotFound();
            }
            await _pricingRepository.UpdatePricingAsync(id, updatePricing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(string id)
        {
            var existingPricing = await _pricingRepository.GetPricingByIdAsync(id);
            if (existingPricing == null)
            {
                return NotFound();
            }
            await _pricingRepository.DeletePricingAsync(id);
            return NoContent();
        }
    }
}
