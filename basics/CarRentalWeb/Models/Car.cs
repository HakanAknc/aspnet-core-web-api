using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRentalWeb.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  // Id

        [BsonElement("brand")]
        public string Brand { get; set; }  // Marka

        [BsonElement("model")]
        public string Model { get; set; }   // Model

        [BsonElement("year")]
        public int Year { get; set; } // Yıl

        [BsonElement("fuelType")]
        public string FuelType { get; set; }  // Yakıt Türü

        [BsonElement("mileage")]
        public int Mileage { get; set; }  // Kilometre
    }
}
