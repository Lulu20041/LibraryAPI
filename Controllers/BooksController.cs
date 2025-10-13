using LibraryAPI.DataAccess.Books;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository repo;

        public BooksController(IBooksRepository repo)
        {
            this.repo = repo;
        }


        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            try
            {
                var books = repo.GetAll();
                return Ok(books);
            }
            catch
            {
                return NotFound("Books not found");
            }
        }

        // GET api/<BooksController>/id
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            try
            {
                Book book = repo.GetById(id);
                return Ok(book);
            }
            catch
            {
                return NotFound("Book not found");
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Book value)
        {
            try
            {
                repo.Add(value);
                return StatusCode(201, "Book added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BooksController>/id
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Book value)
        {
            try
            {
                repo.Update(value);
                return Ok($"Author {value.Id} modified");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                repo.DeleteById(id);
                return Ok($"Book {id} was deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
