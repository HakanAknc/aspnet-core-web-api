using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineDersPlatformuApi.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Title")]
        public string Title { get; set; } = null!;

        [BsonElement("InstructorId")]
        public string InstructorId { get; set; } = null!;

        [BsonElement("StudentIds")]
        public List<string> StudentIds { get; set; } = new List<string>();

        [BsonElement("Description")]
        public string Description { get; set; } = null!;
    }
}
