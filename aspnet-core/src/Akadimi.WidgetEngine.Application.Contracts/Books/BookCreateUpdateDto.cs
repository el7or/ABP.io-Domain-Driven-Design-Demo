using System;
using System.ComponentModel.DataAnnotations;

namespace Akadimi.WidgetEngine.Books
{
    public class BookCreateUpdateDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

    }
}
