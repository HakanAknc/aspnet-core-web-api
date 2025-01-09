using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Data;
using StoreManagementSystem.Models;

namespace StoreManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Tüm ürünleri listeleme
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(ApplicationContext.Products);
        }

        // Yeni ürün ekleme
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            product.Id = ApplicationContext.Products.Count > 0
                ? ApplicationContext.Products.Max(p => p.Id) + 1
                : 1; // Yeni ID belirle
            ApplicationContext.Products.Add(product);
            return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
        }

        // Ürün güncelleme
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = ApplicationContext.Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound("Böyle bir ID bulunamadı dostum");

            // Ürünü güncelle
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;

            return Ok(product); // 200 OK döner
        }

        // Ürün silme
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = ApplicationContext.Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound("Silinecek ID bulunamadı adamım");

            ApplicationContext.Products.Remove(product);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteAllProducts()
        {
            ApplicationContext.Products.Clear();
            return NoContent();
        }
    }
}
