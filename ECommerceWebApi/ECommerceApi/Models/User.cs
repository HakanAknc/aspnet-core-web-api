using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }  // Kullanıcı adı

        [BsonElement("Email")]
        public string Email { get; set; }  // Kullanıcı e-posta adresi

        [BsonElement("Password")]
        public string Password { get; set; }  // Şifre

        [BsonElement("WalletBalance")]
        public decimal WalletBalance { get; set; } = 0; // Kullanıcının cüzdan bakiyesi
    }
}
