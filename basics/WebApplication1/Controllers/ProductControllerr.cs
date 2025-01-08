using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;      // Modeli dahil et

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductControllerr : ControllerBase
    {
        // Örnek veri
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000 },
            new Product { Id = 2, Name = "Phone", Price = 500 }
        };

        // GET api/product
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(Products);   // Ürünleri döndürüyoruz
        }

        // GET api/product/1
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            product.Id = Products.Count + 1;     // Yeni bir ID atıyoruz
            Products.Add(product);               // Ürünü listeye ekliyoruz
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);   // Ürün başarıyla eklendi
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);  // İlgili ürünü bul
            if (product == null)
            {
                return NotFound();     // Ürün bulunamadıysa 404 döner
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return Ok(product);    // Güncellenen ürünü döndür
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);  // İlgili ürünü bul
            if (product == null)
            {
                return NotFound();        // Ürün bulunamadıysa 404 döner
            }

            Products.Remove(product);    // Ürünü listeden çıkar
            return NoContent();         // Başarılı bir silme işlemi
        }
    }
}
