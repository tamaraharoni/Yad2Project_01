﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yad2Project.Models
{
    public class User : IdentityUser<long>
    {
       // public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
     //   public string Email { get; set; }
      //  public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Product> MyProducts { get; set; }


    }
}
