using LibraryAPI.Models;

namespace LibraryAPI.DataAccess
{
    public interface IDataSource
    {
        List<Author> Authors { get; }
        List<Book> Books { get; }
    }
}
