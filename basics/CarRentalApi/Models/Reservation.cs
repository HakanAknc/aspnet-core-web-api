using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRentalApi.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // MongoDB için ID

        [BsonElement("customerId")]
        public string CustomerId { get; set; }  // Müşteri ID'si

        [BsonElement("carId")]
        public string CarId { get; set; } // Araç ID'si

        [BsonElement("startDate")]
        public DateTime StartDate { get; set; } // Kiralama Başlangıç Tarihi

        [BsonElement("endDate")]
        public DateTime EndDate { get; set; } // Kiralama Bitiş Tarihi

        [BsonElement("status")]
        public string Status { get; set; } // Durum (Onaylı, Beklemede, İptal Edildi, vb.
    }
}
