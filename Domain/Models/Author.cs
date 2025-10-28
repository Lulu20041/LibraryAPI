using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>(); 
    }
}
