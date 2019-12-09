using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yad2Project.Models.VM
{
    public class ProductVM
    {

        //Owner     Title   Date   ShortDescription   LongDescription  Price  State  PhotoAvatar  ImageName

        public int Id { get; set; }
        public virtual User Owner { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int State { get; set; }
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
 
    }
}
