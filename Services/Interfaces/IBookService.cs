using LibraryAPI.Domain.Models;
using LibraryAPI.Services.DTO;

namespace LibraryAPI.Services.Interfaces
{
    public interface IBookService
    {
        public Book GetById(int id);

        public List<Book> GetAll();

        public void Add(Book book);

        public void Update(Book book);

        public void Delete(int id);

        public List<Book> GetPublishedAfterYear(int year);

        public List<BooksPerYearDto> GetBooksPerYear();
    }
}
