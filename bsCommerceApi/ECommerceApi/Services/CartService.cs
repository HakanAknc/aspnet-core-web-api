using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class CartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly ProductService _productService;

        public CartService(IRepository<Cart> cartRepository, ProductService productService)
        {
            _cartRepository = cartRepository;
            _productService = productService;
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            var carts = await _cartRepository.GetAllAsync();
            return carts.FirstOrDefault(cart => cart.UserId == userId);
        }

        public async Task AddToCartAsync(string userId, string productId, int quantity)
        {
            var cart = await GetCartByUserIdAsync(userId) ?? new Cart { UserId = userId };
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null) throw new Exception("Product not found!");

            var cartItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price
                });
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            cart.TotalPrice = cart.Items.Sum(item => item.Price * item.Quantity);

            if (string.IsNullOrEmpty(cart.Id))
                await _cartRepository.CreateAsync(cart);
            else
                await _cartRepository.UpdateAsync(cart.Id, cart);
        }

        public async Task RemoveFromCartAsync(string userId, string productId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart == null) throw new Exception("Cart not found!");

            cart.Items.RemoveAll(item => item.ProductId == productId);
            cart.TotalPrice = cart.Items.Sum(item => item.Price * item.Quantity);

            await _cartRepository.UpdateAsync(cart.Id, cart);
        }

        public async Task ClearCartAsync(string userId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart == null) throw new Exception("Cart not found!");

            cart.Items.Clear();
            cart.TotalPrice = 0;

            await _cartRepository.UpdateAsync(cart.Id, cart);
        }
    }
}
