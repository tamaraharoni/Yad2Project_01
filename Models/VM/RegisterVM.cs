using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yad2Project.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last name")]
        [Display (Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter birth datee")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please enter email adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter password confirm")]
        public string Confirm { get; set; }
    }
}
