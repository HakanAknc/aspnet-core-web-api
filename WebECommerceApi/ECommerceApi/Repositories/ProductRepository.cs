using ECommerceApi.Models;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class ProductRepository
    {
        private readonly IMongoCollection<Product> _productsCollection;

        public ProductRepository(IMongoDatabase database)
        {
            _productsCollection = database.GetCollection<Product>("Products");
        }

        // Tüm ürünleri listele
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productsCollection.Find(_ => true).ToListAsync();
        }

        // Ürün ekle
        public async Task CreateProductAsync(Product product)
        {
            await _productsCollection.InsertOneAsync(product);
        }

        // Ürün güncelle
        public async Task UpdateProductAsync(string id, Product updatedProduct)
        {
            await _productsCollection.ReplaceOneAsync(p => p.Id == id, updatedProduct);
        }

        // Ürün sil
        public async Task DeleteProductAsync(string id)
        {
            await _productsCollection.DeleteOneAsync(p => p.Id == id);
        }
    }
}
