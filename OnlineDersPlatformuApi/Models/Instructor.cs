using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineDersPlatformuApi.Models
{
    public class Instructor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("Surname")]
        public string Surname { get; set; } = null!;

        [BsonElement("Expertise")]
        public string Expertise { get; set; } = null!;
    }
}
