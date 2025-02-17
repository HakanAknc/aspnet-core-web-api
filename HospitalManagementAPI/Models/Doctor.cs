using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HospitalManagementAPI.Models
{
    public class Doctor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("tc")]
        public string Tc { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("areaOf​​Expertise")]
        public string AreaOf​​Expertise { get; set; }

        [BsonElement("birthYear")]
        public int BirthYear { get; set; }

        [BsonElement("birthPlace")]
        public string BirthPlace { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("wage")]
        public decimal Wage { get; set; }
    }
}
