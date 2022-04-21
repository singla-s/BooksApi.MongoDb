using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.MongoDb.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [StringLength(100,MinimumLength = 5)]
        [BsonElement("title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [BsonElement("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [Range(20,1000)]
        [BsonElement("author")]
        public string Author { get; set; }
    }
}
