using LibraryAPI.DataAccess;
using LibraryAPI.DataAccess.Authors;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository repo;

        public AuthorsController(IAuthorRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
            try
            {
                var authors = repo.GetAll();
                return Ok(authors);
            }
            catch
            {
                return NotFound("Authors not found");
            }
        }

        // GET api/<AuthorsController>/id
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            try
            {
                Author author = repo.GetById(id);
                return Ok(author);
            }
            catch
            {
                return NotFound("Authors not found");
            }

        }

        // POST api/<AuthorsController>
        [HttpPost]
        public ActionResult<string> Post([FromBody]Author value)
        {
            try
            {
                repo.Add(value);
                return StatusCode(201, "Author added");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<AuthorsController>/id
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody]Author value)
        {
            try
            {
                repo.Update(value);
                return Ok($"Author {value.Id} modified");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                repo.DeleteById(id);
                return Ok($"Author {id} was deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
