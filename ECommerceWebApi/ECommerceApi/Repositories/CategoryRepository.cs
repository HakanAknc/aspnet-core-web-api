using ECommerceApi.Models;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class CategoryRepository
    {
        private readonly IMongoCollection<Category> _categoriesCollection;

        public CategoryRepository(IMongoDatabase database)
        {
            _categoriesCollection = database.GetCollection<Category>("Categories");
        }

        // Tüm kategorileri listele
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoriesCollection.Find(_ => true).ToListAsync();
        }

        // Kategori ekle
        public async Task CreateCategoryAsync(Category category)
        {
            await _categoriesCollection.InsertOneAsync(category);
        }

        // Kategori güncelle
        public async Task UpdateCategoryAsync(string id, Category updatedCategory)
        {
            await _categoriesCollection.ReplaceOneAsync(c => c.Id == id, updatedCategory);
        }

        // Kategori sil
        public async Task DeleteCategoryAsync(string id)
        {
            await _categoriesCollection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
