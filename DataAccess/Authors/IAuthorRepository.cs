using LibraryAPI.Models;

namespace LibraryAPI.DataAccess
{
    public interface IAuthorRepository
    {
        public Author GetById(int id);

        public List<Author> GetAll();

        public void Add(Author book);

        public void Update(Author book);

        public void DeleteById(int id);
    }
}
