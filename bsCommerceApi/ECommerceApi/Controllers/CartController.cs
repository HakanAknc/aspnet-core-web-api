using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Models;
using ECommerceApi.Services;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost("{userId}/add")]
        public async Task<IActionResult> AddToCart(string userId, [FromBody] CartItem item)
        {
            await _cartService.AddToCartAsync(userId, item.ProductId, item.Quantity);
            return NoContent();
        }

        [HttpDelete("{userId}/remove/{productId}")]
        public async Task<IActionResult> RemoveFromCart(string userId, string productId)
        {
            await _cartService.RemoveFromCartAsync(userId, productId);
            return NoContent();
        }

        [HttpDelete("{userId}/clear")]
        public async Task<IActionResult> ClearCart(string userId)
        {
            await _cartService.ClearCartAsync(userId);
            return NoContent();
        }
    }
}
