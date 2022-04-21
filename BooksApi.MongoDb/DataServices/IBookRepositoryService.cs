using BooksApi.MongoDb.Models;
using System.Collections.Generic;

namespace BooksApi.MongoDb.DataServices
{
    public interface IBookRepositoryService
    {
        //Return list of books
        //when Serialized into json into an array
        List<Book> GetAllBooks();
        List<Book> GetBooksByTitle(string searchStrinng);
        Book GetBookById(int id);
        Book AddBook(Book newBook);
        Book updateBook(int id, Book book);
        Book DeleteBook(int id, Book book);
    }
}
