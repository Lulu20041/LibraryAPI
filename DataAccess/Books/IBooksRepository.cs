using LibraryAPI.Models;

namespace LibraryAPI.DataAccess.Books
{
    public interface IBooksRepository
    {
        public Book GetById(int id);

        public List<Book> GetAll();

        public void Add(Book book);

        public void Update(Book book);

        public void DeleteById(int id);
    }
}
