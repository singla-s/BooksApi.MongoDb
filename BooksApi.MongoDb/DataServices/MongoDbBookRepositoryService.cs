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
        }

        public Book AddBook(Book newBook)
        {
            throw new NotImplementedException();
        }

        public Book DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooksByTitl(string searchStrinng)
        {
            throw new NotImplementedException();
        }

        public Book updateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
