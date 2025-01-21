using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace KutuphaneYonetimSistemi.Models
{
    public class Kitap
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Baslik")]
        public string Baslik { get; set; } = null!;

        public string Yazar { get; set; } = null!;
        public string Yayinevi { get; set; } = null!;
        public int BasimYili { get; set; }
        public string Tur { get; set; } = null!;
    }
}
