using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } // Ürün adı

        [BsonElement("Description")]
        public string Description { get; set; } // Ürün açıklaması

        [BsonElement("Price")]
        public decimal Price { get; set; } // Ürün fiyatı

        [BsonElement("StockQuantity")]
        public int StockQuantity { get; set; } // Stok miktarı

        [BsonElement("Category")]
        public string Category { get; set; } // Ürün kategorisi
    }
}
