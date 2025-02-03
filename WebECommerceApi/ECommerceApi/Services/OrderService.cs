using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Order>> GetAllOrdersAsync() => _orderRepository.GetAllOrdersAsync();

        public Task<Order> GetOrderByIdAsync(string id) => _orderRepository.GetOrderByIdAsync(id);

        public Task CreateOrderAsync(Order order) => _orderRepository.CreateOrderAsync(order);

        public Task UpdateOrderAsync(string id, Order order) => _orderRepository.UpdateOrderAsync(id, order);

        public Task DeleteOrderAsync(string id) => _orderRepository.DeleteOrderAsync(id);
    }
}
