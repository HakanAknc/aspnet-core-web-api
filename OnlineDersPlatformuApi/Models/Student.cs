using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineDersPlatformuApi.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("Surname")]
        public string Surname { get; set; } = null!;

        [BsonElement("EnrolledCourses")]
        public List<string> EnrolledCourses { get; set; } = new List<string>();
    }
}
