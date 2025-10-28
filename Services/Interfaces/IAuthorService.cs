using LibraryAPI.Domain.Models;
using LibraryAPI.Services.DTO;

namespace LibraryAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        public Author GetById(int id);

        public List<Author> GetAll();

        public void Add(Author author);

        public void Update(Author author);

        public void Delete(int id);

        public List<Author> FindAllByName(string name);

        public List<AuthorsWithBookCountDto> GetAuthorsWithBookCountDto();
    }
}
