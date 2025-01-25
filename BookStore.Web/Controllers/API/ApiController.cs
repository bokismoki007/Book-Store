using BookStore.Domain.Models.Domain;
using BookStore.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IBookService _bookService;

        public ApiController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("[action]")]
        public List<Book> GetAllBooks()
        {
            return this._bookService.GetAllBooks();
        }
        [HttpPost("[action]")]
        public Book GetDetails(Guid? id)
        {
            return this._bookService.GetDetailsForBook(id);
        }
    }
}
