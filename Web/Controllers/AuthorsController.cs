using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Models;
using LibraryAPI.Services.DTO;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService service;

        public AuthorsController(IAuthorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
            var authors = service.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Author> Get(int id)
        {
            Author author = service.GetById(id);
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody]Author value)
        {
            service.Add(value);
            return StatusCode(201, "Author added");
        }

        [HttpPut("{id:int}")]
        public ActionResult<string> Put(int id, [FromBody]Author value)
        {

            service.Update(value);
            return Ok($"Author {value.Id} modified");
            
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> Delete(int id)
        {
            service.Delete(id);
            return Ok($"Author {id} was deleted");
        }

        [HttpGet("{name}")]
        public ActionResult<List<Author>> GetAllByName(string name)
        {
            var authors = service.FindAllByName(name);
            return Ok(authors);
        }

        [HttpGet("with-book-count")]
        public ActionResult<List<AuthorsWithBookCountDto>> GetWithBookCount()
        {
            var authors = service.GetAuthorsWithBookCountDto();
            return Ok(authors);
        }
    }
}
