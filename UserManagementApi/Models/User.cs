using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagementApi.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
