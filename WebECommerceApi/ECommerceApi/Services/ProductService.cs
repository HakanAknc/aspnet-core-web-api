using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> GetAllProductsAsync() => _productRepository.GetAllProductsAsync();

        public Task CreateProductAsync(Product product) => _productRepository.CreateProductAsync(product);

        public Task UpdateProductAsync(string id, Product product) => _productRepository.UpdateProductAsync(id, product);

        public Task DeleteProductAsync(string id) => _productRepository.DeleteProductAsync(id);
    }
}
