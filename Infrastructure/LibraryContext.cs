using LibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Infrastructure
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne()
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "J.K. Rowling", DateOfBirth = new DateTime(1965, 7, 31) },
                new Author { Id = 2, Name = "George Orwell", DateOfBirth = new DateTime(1903, 6, 25) },
                new Author { Id = 3, Name = "Jane Austen", DateOfBirth = new DateTime(1775, 12, 16) },
                new Author { Id = 4, Name = "Stephen King", DateOfBirth = new DateTime(1947, 9, 21) },
                new Author { Id = 5, Name = "Agatha Christie", DateOfBirth = new DateTime(1890, 9, 15) },
                new Author { Id = 6, Name = "J.R.R. Tolkien", DateOfBirth = new DateTime(1892, 1, 3) },
                new Author { Id = 7, Name = "Ernest Hemingway", DateOfBirth = new DateTime(1899, 7, 21) },
                new Author { Id = 8, Name = "F. Scott Fitzgerald", DateOfBirth = new DateTime(1896, 9, 24) }
            };

            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", PublishedYear = 1997, AuthorId = 1 },
                new Book { Id = 2, Title = "Harry Potter and the Chamber of Secrets", PublishedYear = 1998, AuthorId = 1 },
                new Book { Id = 3, Title = "Harry Potter and the Prisoner of Azkaban", PublishedYear = 1999, AuthorId = 1 },
                new Book { Id = 4, Title = "Harry Potter and the Goblet of Fire", PublishedYear = 2000, AuthorId = 1 },
                new Book { Id = 5, Title = "The Casual Vacancy", PublishedYear = 2012, AuthorId = 1 },
                new Book { Id = 6, Title = "1984", PublishedYear = 1949, AuthorId = 2 },
                new Book { Id = 7, Title = "Animal Farm", PublishedYear = 1945, AuthorId = 2 },
                new Book { Id = 8, Title = "Homage to Catalonia", PublishedYear = 1938, AuthorId = 2 },
                new Book { Id = 9, Title = "Pride and Prejudice", PublishedYear = 1813, AuthorId = 3 },
                new Book { Id = 10, Title = "Sense and Sensibility", PublishedYear = 1811, AuthorId = 3 },
                new Book { Id = 11, Title = "Emma", PublishedYear = 1815, AuthorId = 3 },
                new Book { Id = 12, Title = "Mansfield Park", PublishedYear = 1814, AuthorId = 3 },
                new Book { Id = 13, Title = "The Shining", PublishedYear = 1977, AuthorId = 4 },
                new Book { Id = 14, Title = "It", PublishedYear = 1986, AuthorId = 4 },
                new Book { Id = 15, Title = "The Stand", PublishedYear = 1978, AuthorId = 4 },
                new Book { Id = 16, Title = "Carrie", PublishedYear = 1974, AuthorId = 4 },
                new Book { Id = 17, Title = "Misery", PublishedYear = 1987, AuthorId = 4 },
                new Book { Id = 18, Title = "Murder on the Orient Express", PublishedYear = 1934, AuthorId = 5 },
                new Book { Id = 19, Title = "Death on the Nile", PublishedYear = 1937, AuthorId = 5 },
                new Book { Id = 20, Title = "The Murder of Roger Ackroyd", PublishedYear = 1926, AuthorId = 5 },
                new Book { Id = 21, Title = "And Then There Were None", PublishedYear = 1939, AuthorId = 5 },
                new Book { Id = 22, Title = "The Hobbit", PublishedYear = 1937, AuthorId = 6 },
                new Book { Id = 23, Title = "The Fellowship of the Ring", PublishedYear = 1954, AuthorId = 6 },
                new Book { Id = 24, Title = "The Two Towers", PublishedYear = 1954, AuthorId = 6 },
                new Book { Id = 25, Title = "The Return of the King", PublishedYear = 1955, AuthorId = 6 },
                new Book { Id = 26, Title = "The Old Man and the Sea", PublishedYear = 1952, AuthorId = 7 },
                new Book { Id = 27, Title = "A Farewell to Arms", PublishedYear = 1929, AuthorId = 7 },
                new Book { Id = 28, Title = "For Whom the Bell Tolls", PublishedYear = 1940, AuthorId = 7 },
                new Book { Id = 29, Title = "The Great Gatsby", PublishedYear = 1925, AuthorId = 8 },
                new Book { Id = 30, Title = "Tender Is the Night", PublishedYear = 1934, AuthorId = 8 },
                new Book { Id = 31, Title = "This Side of Paradise", PublishedYear = 1920, AuthorId = 8 }
            };

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
