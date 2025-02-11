using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRentalApi.Models
{
    public class Pricing
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("carType")]
        public string CarType { get; set; } = string.Empty;  // Araç Tipi (Sedan, SUV, vb.)

        [BsonElement("dailyRate")]
        public decimal DailyRate { get; set; }  // Günlük Fiyat

        [BsonElement("weeklyRate")]
        public decimal WeeklyRate { get; set; }   // Haftalık Fiyat

        [BsonElement("monthlyRate")]
        public decimal MonthlyRate { get; set; }  // Aylık Fiyat

        [BsonElement("isActive")]
        public bool IsActive { get; set; } // Aktif Kampanya Durumu
    }
}
