using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CarProject.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("brand")]
        public string Brand { get; set; } = string.Empty;

        [BsonElement("model")]
        public string Model { get; set; } = string.Empty;

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("fuelType")]
        public string FuelType { get; set; } = string.Empty;

        [BsonElement("isAvailavle")]
        public bool IsAvailable { get; set; }

        [BsonElement("pricePerDay")]
        public decimal PricePerDay { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = false;

        [BsonElement("createTime")]
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;

        [BsonElement("modifyTime")]
        public DateTime ModifyTime { get; set; } = DateTime.UtcNow;
    }
}
