using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductsAsync() => await _productRepository.GetAllAsync();

        public async Task<Product> GetProductByIdAsync(string id) => await _productRepository.GetByIdAsync(id);

        public async Task CreateProductAsync(Product product) => await _productRepository.CreateAsync(product);

        public async Task UpdateProductAsync(string id, Product product) => await _productRepository.UpdateAsync(id, product);

        public async Task DeleteProductAsync(string id) => await _productRepository.DeleteAsync(id);

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            var products = await _productRepository.GetAllAsync();
            return products.Where(p => p.Category == category).ToList();
        }
    }
}
