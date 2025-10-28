using LibraryAPI.Domain.Models;

namespace LibraryAPI.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        public Author GetById(int id);

        public IQueryable<Author> GetAll();

        public void Insert(Author book);

        public void Update(Author book);

        public void DeleteById(int id);
    }
}
