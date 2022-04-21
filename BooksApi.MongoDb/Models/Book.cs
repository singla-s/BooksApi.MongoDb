using BooksApi.MongoDb.Validator;
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
        public string _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [StringLength(100,MinimumLength = 5)]
        [BsonElement("title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [ReleaseDateValidator]
        [BsonElement("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [Range(20, 1000)]
        [BsonElement("price")]
        public double Price { get; set; }

        
        [BsonElement("author")]
        public string Author { get; set; }
    }
}
