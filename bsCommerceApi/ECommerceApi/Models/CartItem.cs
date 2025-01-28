using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceApi.Models
{
    public class CartItem
    {
        [BsonElement("productId")]
        public string ProductId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; } // Birim fiyat
    }
}
