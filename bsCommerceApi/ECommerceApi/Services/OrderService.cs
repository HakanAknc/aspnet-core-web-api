using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly CartService _cartService;

        public OrderService(IRepository<Order> orderRepository, CartService cartService)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
        }

        public async Task<Order> CreateOrderAsync(string userId)
        {
            // Kullanıcının sepetini al
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            if (cart == null || !cart.Items.Any())
                throw new Exception("Sepet boş!");

            // Sipariş oluştur
            var order = new Order
            {
                UserId = userId,
                Items = cart.Items,
                TotalPrice = cart.TotalPrice
            };

            await _orderRepository.CreateAsync(order);

            // Sepeti temizle
            await _cartService.ClearCartAsync(userId);

            return order;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Where(order => order.UserId == userId).ToList();
        }

        public async Task UpdateOrderStatusAsync(string orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Sipariş bulunamadı!");

            order.Status = status;
            await _orderRepository.UpdateAsync(orderId, order);
        }
    }
}
