using System;
using System.Collections.Generic;
using BooksApi.MongoDb.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace BooksApi.MongoDb.DataServices
{
    public class MongoDbBookRepositoryService : IBookRepositoryService
    {
        private readonly IMongoCollection<Book> _books;

        public MongoDbBookRepositoryService(IConfiguration appConfig)
        {
            var mongoClient = new MongoClient(appConfig.GetConnectionString("BooksDbConSring"));
            var database = mongoClient.GetDatabase("booksDb");

            this._books = database.GetCollection<Book>("books");
        }

        public List<Book> GetAllBooks()
        {
            return _books.Find<Book>(book => true).ToList();
        }

        public Book GetBookById(int id)
        {
            return _books.Find<Book>(book => book.Id == id).FirstOrDefault();
        }

        public List<Book> GetBooksByTitle(string searchStrinng)
        {
            return _books.Find<Book>(book => book.Title.Contains(searchStrinng)).ToList();
        }

        public Book AddBook(Book newBook)
        {
            _books.InsertOne(newBook);
            return GetBookById(newBook.Id);
        }

        public Book DeleteBook(int id, Book book)
        {
            _books.DeleteOne(book => book.Id == id);
            return book;
        }

        public Book updateBook(int id, Book updatedBook)
        {
            this._books.ReplaceOne<Book>(book => book.Id == id, updatedBook);
            var result = _books.Find<Book>(book => book.Id == id).FirstOrDefault();
            return result;
        }
    }
}
