using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceApi.Models
{
    public class Wallet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; } // Cüzdan sahibinin kullanıcı ID'si

        [BsonElement("Balance")]
        public decimal Balance { get; set; } // Cüzdan bakiyesi
    }
}
