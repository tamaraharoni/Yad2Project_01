using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yad2Project.Models
{
    public class LoginVM
    {
        [Display(Name = "User Name")]
       public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remeber me")]
        public bool RemeberMe { get; set; }
       
    }


}
