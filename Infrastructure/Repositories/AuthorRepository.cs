using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Models;

namespace LibraryAPI.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext context;

        public AuthorRepository(LibraryContext context)
        {
            this.context = context;
        }

        public Author GetById(int id)
        {
            Author author = context.Authors.First(a => a.Id == id);
            return author;
        }

        public IQueryable<Author> GetAll()
        {
            return context.Authors;
        }

        public void Insert(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public void Update(Author author)
        {
            Author newAuthor = context.Authors.First(a => a.Id == author.Id);
            newAuthor.Name = author.Name;
            newAuthor.DateOfBirth = author.DateOfBirth;
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Author author = context.Authors.First(a => a.Id == id);
            context.Authors.Remove(author);
            context.SaveChanges();
        }
    }
}
