using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceApi.Models
{
    public class Inventory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ProductId")]
        public string ProductId { get; set; } // Stok yönetimi yapılacak ürünün ID'si

        [BsonElement("Quantity")]
        public int Quantity { get; set; } // Ürünün mevcut stok miktarı
    }
}
