using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRentalApi.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;  // Id

        [BsonElement("brand")]
        public string Brand { get; set; } = string.Empty;  // Marka

        [BsonElement("model")]
        public string Model { get; set; } = string.Empty;  // Model

        [BsonElement("year")]
        public int Year { get; set; }                      // Yıl

        [BsonElement("fuelType")]
        public string FuelType { get; set; } = string.Empty;  // Yakıt Tipi

        [BsonElement("ısAvailable")]
        public bool IsAvailable { get; set; } = true;  // Kiralama Durumu

        [BsonElement("pricePerDay")]
        public decimal PricePerDay { get; set; }  // Günlük Fiyat
    }
}
