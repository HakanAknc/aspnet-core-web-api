using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Models;
using ECommerceApi.Services;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{userId}/create")]
        public async Task<IActionResult> CreateOrder(string userId)
        {
            try
            {
                var order = await _orderService.CreateOrderAsync(userId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrders(string userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(string orderId, [FromBody] string status)
        {
            try
            {
                await _orderService.UpdateOrderStatusAsync(orderId, status);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
