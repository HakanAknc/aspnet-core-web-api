using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExampleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // Geçici olarak ürünleri bir liste içinde tutacağız
        private static List<string> products = new List<string> { "Telefon", "Laptop", "Tablet" };

        // 1. GET: Tüm ürünleri getir
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }

        // 2. GET: Belirli bir ürünü getir
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound("Ürün bulunamadı!");

            return Ok(products[id]);
        }

        // 3. POST: Yeni ürün ekle
        [HttpPost]
        public IActionResult AddProduct([FromBody] string product)
        {
            products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = products.Count - 1 }, product);
        }

        // 4. PUT: Var olan ürünü güncelle
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] string updatedProduct)
        {
            if (id < 0 || id >= products.Count)
                return NotFound("Ürün bulunamadı!");

            products[id] = updatedProduct;
            return NoContent();
        }

        // 5. DELETE: Ürünü sil
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound("Ürün bulunamadı!");

            products.RemoveAt(id);
            return NoContent();
        }
    }
}
