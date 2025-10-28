using LibraryAPI.Domain.Models;
using LibraryAPI.Services.DTO;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService service;

        public BooksController(IBookService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            var books = service.GetAll();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Book> Get(int id)
        {
            Book book = service.GetById(id);
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Book value)
        {
            service.Add(value);
            return StatusCode(201, "Book added");
        }

        [HttpPut("{id:int}")]
        public ActionResult<string> Put(int id, [FromBody] Book value)
        {
            service.Update(value);
            return Ok($"Author {value.Id} modified");
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> Delete(int id)
        {
            service.Delete(id);
            return Ok($"Book {id} was deleted");
        }

        [HttpGet("published-after")]
        public ActionResult<List<Book>> GetPublishedAfterYear([FromQuery] int year)
        {
            var books = service.GetPublishedAfterYear(year);
            return Ok(books);
        }

        [HttpGet("per-year")]
        public ActionResult<List<BooksPerYearDto>> GetPerYear()
        {
            var books = service.GetBooksPerYear();
            return Ok(books);
        }

    }
}
