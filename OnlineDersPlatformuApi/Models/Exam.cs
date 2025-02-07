using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineDersPlatformuApi.Models
{
    public class Exam
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("CourseId")]
        public string CourseId { get; set; } = null!;

        [BsonElement("Title")]
        public string Title { get; set; } = null!;

        [BsonElement("Questions")]
        public List<string> Questions { get; set; } = new();

        [BsonElement("MaxScore")]
        public int MaxScore { get; set; }
    }
}
