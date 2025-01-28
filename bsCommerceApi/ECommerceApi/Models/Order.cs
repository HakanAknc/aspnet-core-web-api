using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceApi.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("items")]
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        [BsonElement("totalPrice")]
        public decimal TotalPrice { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = "Oluşturuldu";

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
