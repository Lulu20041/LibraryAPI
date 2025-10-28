using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Models;
using LibraryAPI.Services.DTO;
using LibraryAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository repo;

        public AuthorService(IAuthorRepository repo)
        {
            this.repo = repo;
        }

        public Author GetById(int id) => repo.GetById(id);

        public List<Author> GetAll() => repo.GetAll().ToList();

        public void Add(Author author) => repo.Insert(author);

        public void Update(Author author) => repo.Update(author);

        public void Delete(int id) => repo.DeleteById(id);

        public List<Author> FindAllByName(string name)
        {
            var authors = repo.GetAll().Where(a => a.Name.StartsWith(name)).ToList();
            return authors;
        }

        public List<AuthorsWithBookCountDto> GetAuthorsWithBookCountDto()
        {
            var authors = repo.GetAll()
                .Include(a => a.Books)
                .Select(a => new AuthorsWithBookCountDto
            {
                Name = a.Name,
                Count = a.Books.Count
            })
                .ToList();

            return authors;
        }

    }
}
