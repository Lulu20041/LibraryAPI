using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Models;
using LibraryAPI.Services.DTO;
using LibraryAPI.Services.Interfaces;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository repo;

        public BookService(IBooksRepository repo)
        {
            this.repo = repo;
        }

        public Book GetById(int id) => repo.GetById(id);

        public List<Book> GetAll() => repo.GetAll().ToList();

        public void Add(Book book) => repo.Insert(book);

        public void Update(Book book) => repo.Update(book);

        public void Delete(int id) => repo.DeleteById(id);

        public List<Book> GetPublishedAfterYear(int year)
        {
            var books = repo.GetAll().Where(b => b.PublishedYear >= year).ToList();
            return books;
        }

        public List<BooksPerYearDto> GetBooksPerYear()
        {
            var books = repo.GetAll()
                .GroupBy(b => b.PublishedYear)
                .Select(s => new BooksPerYearDto { Year = s.Key, Count = s.Count() })
                .OrderBy(b => b.Year)
                .ToList();
            return books;
        }
    }
}
