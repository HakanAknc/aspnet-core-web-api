using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<List<Category>> GetAllCategoriesAsync() => _categoryRepository.GetAllCategoriesAsync();

        public Task CreateCategoryAsync(Category category) => _categoryRepository.CreateCategoryAsync(category);

        public Task UpdateCategoryAsync(string id, Category category) => _categoryRepository.UpdateCategoryAsync(id, category);

        public Task DeleteCategoryAsync(string id) => _categoryRepository.DeleteCategoryAsync(id);
    }
}
