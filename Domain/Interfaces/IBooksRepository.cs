using LibraryAPI.Domain.Models;

namespace LibraryAPI.Domain.Interfaces
{
    public interface IBooksRepository
    {
        public Book GetById(int id);

        public IQueryable<Book> GetAll();

        public void Insert(Book book);

        public void Update(Book book);

        public void DeleteById(int id);
    }
}
