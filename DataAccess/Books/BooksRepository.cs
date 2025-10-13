using LibraryAPI.Models;

namespace LibraryAPI.DataAccess.Books
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IDataSource ds;

        public BooksRepository(IDataSource ds)
        {
            this.ds = ds;
        }

        public Book GetById(int id)
        {
            Book book = ds.Books.First(b => b.Id == id);
            return book;
        }

        public List<Book> GetAll()
        {
            return ds.Books;
        }

        public void Add(Book book)
        {
            ds.Books.Add(book);
        }

        public void Update(Book book)
        {
            Book newBook = ds.Books.First(a => a.Id == book.Id);
            newBook.Title = book.Title;
            newBook.PublishedYear = book.PublishedYear;
            newBook.AuthorId = book.AuthorId;
        }

        public void DeleteById(int id)
        {
            Book newBook = ds.Books.First(a => a.Id == id);
            ds.Books.Remove(newBook);
        }
    }
}
