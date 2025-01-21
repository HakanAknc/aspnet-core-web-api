using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMongoDatabase _database;

    public ProductController(IMongoDatabase database)
    {
        _database = database;
    }

    [HttpGet("list")]
    public IActionResult TestConnection()
    {
        try
        {
            // MongoDB'ye bağlantıyı kontrol et
            var collections = _database.ListCollectionNames().ToList();
            return Ok(new { Message = "MongoDB'ye başarıyla bağlanıldı.", Collections = collections });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Bağlantı hatası.", Error = ex.Message });
        }
    }

    // Veri eklemek için yeni bir endpoint ekleyelim
    [HttpPost("add")]
    public IActionResult AddProduct([FromBody] Product product)
    {
        var collection = _database.GetCollection<Product>("Products");

        // Veriyi koleksiyona ekle
        collection.InsertOne(product);

        return Ok(new { Message = "Ürün başarıyla eklendi", Product = product });
    }
}

// Ürün sınıfını tanımlayalım
public class Product
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Job { get; set; }
}
