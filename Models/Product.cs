using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yad2Project.Models
{
    public class Product
    {

        public int Id { get; set; }

        [InverseProperty("MyProducts")]
        public virtual User Owner { get; set; }
        [InverseProperty("MyProducts")]
        public virtual int OwnerId { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    
        public int State { get; set; }
        [NotMapped]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
        //  public ImageInfo[] Images { get; set; }


      //  public Product()
      //  {
           // Images = new ImageInfo[3];


       // }
    }
}
