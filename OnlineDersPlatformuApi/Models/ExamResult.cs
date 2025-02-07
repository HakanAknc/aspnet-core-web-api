using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineDersPlatformuApi.Models
{
    public class ExamResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("ExamId")]
        public string ExamId { get; set; } = null!;

        [BsonElement("StudentId")]
        public string StudentId { get; set; } = null!;

        [BsonElement("Score")]
        public int Score { get; set; }
    }
}
