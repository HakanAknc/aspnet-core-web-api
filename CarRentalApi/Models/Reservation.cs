using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRentalApi.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("customerId")]
        public string CustomerId { get; set; } = string.Empty;  // müşteri Id'si

        [BsonElement("carId")]
        public string CarId { get; set; } = string.Empty;   // Araç Id'si

        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }  //  Rezervasyon Başlangıç Tarihi

        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }  //  Rezervasyon Bitiş Tarihi

        [BsonElement("totalPrice")]
        public decimal TotalPrice { get; set; }  // Toplam Fiyat
    }
}
