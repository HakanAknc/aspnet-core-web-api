using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("subcategory")]
        public string Subcategory { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
