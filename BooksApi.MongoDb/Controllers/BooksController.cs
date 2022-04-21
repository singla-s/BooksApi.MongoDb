using Microsoft.AspNetCore.Mvc;

namespace BooksApi.MongoDb.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
