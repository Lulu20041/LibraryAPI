using LibraryAPI.Models;

namespace LibraryAPI.DataAccess.Authors
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDataSource ds;

        public AuthorRepository(IDataSource ds)
        {
            this.ds = ds;
        }

        public Author GetById(int id)
        {
            Author author = ds.Authors.First(a => a.Id == id);
            return author;
        }

        public List<Author> GetAll()
        {
            return ds.Authors;
        }

        public void Add(Author author)
        {
            ds.Authors.Add(author);
        }

        public void Update(Author author)
        {
            Author newAuthor = ds.Authors.First(a => a.Id == author.Id);
            newAuthor.Name = author.Name;
            newAuthor.DateOfBirth = author.DateOfBirth;
        }

        public void DeleteById(int id)
        {
            Author author = ds.Authors.First(a => a.Id == id);
            ds.Authors.Remove(author);
        }
    }
}
