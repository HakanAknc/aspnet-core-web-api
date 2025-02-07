using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineDersPlatformuApi.Models
{
    public class CourseContent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Name")]
        public string CourseId { get; set; } = null!;

        [BsonElement("CourseId")]
        public string Title { get; set; } = null!;

        [BsonElement("Description")]
        public string Description { get; set; } = null!;
    }
}
