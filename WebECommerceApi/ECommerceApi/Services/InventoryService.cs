using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryService(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public Task<List<Inventory>> GetAllInventoryAsync() => _inventoryRepository.GetAllInventoryAsync();

        public Task<Inventory> GetInventoryByProductIdAsync(string productId) => _inventoryRepository.GetInventoryByProductIdAsync(productId);

        public Task UpdateStockAsync(string productId, int quantity) => _inventoryRepository.UpdateStockAsync(productId, quantity);
    }
}
