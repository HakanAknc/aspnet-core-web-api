using ECommerceApi.Models;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // Tüm stokları listele
        [HttpGet]
        public async Task<IActionResult> GetAllInventory()
        {
            var inventory = await _inventoryService.GetAllInventoryAsync();
            return Ok(inventory);
        }

        // Ürün stok bilgisi getir
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetInventoryByProductId(string productId)
        {
            var inventory = await _inventoryService.GetInventoryByProductIdAsync(productId);
            if (inventory == null) return NotFound();
            return Ok(inventory);
        }

        // Stok güncelle
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateStock(string productId, int quantity)
        {
            await _inventoryService.UpdateStockAsync(productId, quantity);
            return NoContent();
        }
    }
}
