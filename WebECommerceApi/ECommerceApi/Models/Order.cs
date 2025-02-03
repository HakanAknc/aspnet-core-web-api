using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ECommerceApi.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; } // Siparişi oluşturan kullanıcı ID'si

        [BsonElement("ProductIds")]
        public string[] ProductIds { get; set; } // Siparişteki ürünlerin ID'leri

        [BsonElement("TotalPrice")]
        public decimal TotalPrice { get; set; } // Toplam fiyat

        [BsonElement("OrderDate")]
        public DateTime OrderDate { get; set; } = DateTime.Now; // Sipariş tarihi

        [BsonElement("Status")]
        public string Status { get; set; } = "Pending"; // Sipariş durumu (Pending, Shipped, Delivered)
    }
}
