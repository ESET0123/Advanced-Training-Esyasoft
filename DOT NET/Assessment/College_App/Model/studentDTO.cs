using CollegeApp.Model.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Model
{
    public class studentDTO
    {
        [ValidateNever]
        public int studentID { get; set; }
        [Required(ErrorMessage = "please enter the name")]
        [StringLength(100)]
        [SpaceCheck]
        //[FirstCapitalCheck]
        public string name { get; set; }
        [Range(10, 30)]
        public int age { get; set; }

        [EmailAddress(ErrorMessage = "enter proper email")]
        public string email { get; set; }
        //[SpaceCheck]
        //public string password { get; set; }
        //[Compare(nameof(password))]]
        //public string comparepassword { get; set; }
    }
}
