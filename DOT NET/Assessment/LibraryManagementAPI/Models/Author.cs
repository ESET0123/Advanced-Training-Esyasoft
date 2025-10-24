using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAPI.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        //public ICollection<Book> Books { get; set; }
        //ICollection<Book>? Books
    }
}
