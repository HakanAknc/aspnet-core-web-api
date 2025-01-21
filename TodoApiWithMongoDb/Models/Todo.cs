using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoApiWithMongoDb.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        public bool IsComplete { get; set; }
    }
}
