using BooksApi.MongoDb.DataServices;
using BooksApi.MongoDb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.MongoDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepositoryService _bookRepositoryService;
        public BooksController(IBookRepositoryService dataService)
        {
            _bookRepositoryService = dataService;
        }

        [HttpGet]
        public List<Book> GetAllBooks()
        {
            return _bookRepositoryService.GetAllBooks();
        }

        [HttpGet]
        [Route("search/{searchText}")]
        public List<Book> GetBooksByTitle(string searchText)
        {
            return _bookRepositoryService.GetBooksByTitle(searchText);
        }

        [HttpPost]
        public Book AddNewBook(Book newBook)
        {
            return _bookRepositoryService.AddBook(newBook);
        }

        [HttpPut]
        public Book UpdateBook(int id, Book book)
        {
            return _bookRepositoryService.updateBook(id, book);
        }

        [HttpDelete]
        public Book RemoveBook(int id, Book book)
        {
            return _bookRepositoryService.DeleteBook(id, book);
        }


    }
}
