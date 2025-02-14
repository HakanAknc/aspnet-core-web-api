using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace UserManagementAPI.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("tc")]
        public string Tc { get; set; } = string.Empty;

        [BsonElement("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [BsonElement("lastName")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("birthYear")]
        public int BirthYear { get; set; }

        [BsonElement("birthPlace")]
        public string BirthPlace { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("job")]
        public string Job { get; set; } = string.Empty;

        [BsonElement("salary")]
        public decimal Salary { get; set; }
    }
}
