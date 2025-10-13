using LibraryAPI.Models;

namespace LibraryAPI.DataAccess
{
    public class DataSource : IDataSource
    {
        private List<Author> authors;
        private List<Book> books;

        public DataSource()
        {
            authors = new List<Author>
        {
            new Author { Id = 1, Name = "Лев Толстой", DateOfBirth = new DateTime(1828, 9, 9) },
            new Author { Id = 2, Name = "Фёдор Достоевский", DateOfBirth = new DateTime(1821, 11, 11) },
            new Author { Id = 3, Name = "Антон Чехов", DateOfBirth = new DateTime(1860, 1, 29) }
        };

            books = new List<Book>
        {
            new Book { Id = 1, Title = "Война и мир", PublishedYear = 1869, AuthorId = 1 },
            new Book { Id = 2, Title = "Анна Каренина", PublishedYear = 1877, AuthorId = 1 },
            new Book { Id = 3, Title = "Преступление и наказание", PublishedYear = 1866, AuthorId = 2 },
            new Book { Id = 4, Title = "Идиот", PublishedYear = 1869, AuthorId = 2 },
            new Book { Id = 5, Title = "Вишнёвый сад", PublishedYear = 1904, AuthorId = 3 },
            new Book { Id = 6, Title = "Чайка", PublishedYear = 1896, AuthorId = 3 }
        };
        }

        public List<Author> Authors => authors;
        public List<Book> Books => books;
    }
}
