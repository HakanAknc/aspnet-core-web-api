﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LibraryProject.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }
    }
}
