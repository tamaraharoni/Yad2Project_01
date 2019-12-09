using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yad2Project.Models.VM
{
    public class RegisterModel
    {
        public int Id { get; set; }
        [Display(Name = "User Name")]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false)]
        [Compare("Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false)]
        public string Confirm { get; set; }

        [Display(Name = "Email Address")]
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Is Admin")]
        public bool IsAdmin { get; set; }
    }
}
