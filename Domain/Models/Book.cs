using LibraryAPI.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [YearRange(-5000)]
        public int PublishedYear { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
