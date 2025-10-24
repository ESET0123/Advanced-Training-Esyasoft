using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeApp.Data
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentID { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
    }
}
