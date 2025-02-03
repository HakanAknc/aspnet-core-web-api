using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ECommerceApi.Models
{
    public class User
    {
                   // MongoDB isimlendirmeleri küçük veya camelCase olarak yapılır. ID'leri de genelde en yukarda toplamaya çalış
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  // Kullanıcı ID

        [BsonElement("Name")]
        public string Name { get; set; }  // Kullanıcı adı

        [BsonElement("Email")]
        public string Email { get; set; }  // Kullanıcı e-posta adresi

        [BsonElement("Password")]
        //[JsonIgnore] // Bu şekilde bir tanımlama, Password'ün JSON çıktısında görünmesini engeller (Ama bu bir sorun)
        public string Password { get; set; }  // Kullanıcı Şifre

        [BsonElement("WalletBalance")]
        public decimal WalletBalance { get; set; } = 0; // Kullanıcının cüzdan bakiyesi başta default olarak sıfır atanmış

    }
}
