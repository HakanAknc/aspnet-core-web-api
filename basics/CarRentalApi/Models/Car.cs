using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRentalApi.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("brand")]
        public string Brand { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("dailyPrice")]
        public decimal DailyPrice { get; set; }

        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}
