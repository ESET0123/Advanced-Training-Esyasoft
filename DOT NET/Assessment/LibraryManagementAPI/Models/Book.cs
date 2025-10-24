using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        //public int AuthorId {  get; set; }
        //public Author AuthorName { get; set; }

        //Author? Author
    }
}
