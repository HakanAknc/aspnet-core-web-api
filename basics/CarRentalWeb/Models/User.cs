using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRentalWeb.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("job")]
        public string Job { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

    }
}
