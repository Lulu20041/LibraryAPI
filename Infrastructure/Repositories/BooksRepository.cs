using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Models;

namespace LibraryAPI.Infrastructure.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly LibraryContext context;

        public BooksRepository(LibraryContext context)
        {
            this.context = context;
        }

        public Book GetById(int id)
        {
            Book book = context.Books.First(b => b.Id == id);
            return book;
        }

        public IQueryable<Book> GetAll()
        {
            return context.Books;
        }

        public void Insert(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void Update(Book book)
        {
            Book newBook = context.Books.First(a => a.Id == book.Id);
            newBook.Title = book.Title;
            newBook.PublishedYear = book.PublishedYear;
            newBook.AuthorId = book.AuthorId;
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Book newBook = context.Books.First(a => a.Id == id);
            context.Books.Remove(newBook);
            context.SaveChanges();
        }
    }
}
