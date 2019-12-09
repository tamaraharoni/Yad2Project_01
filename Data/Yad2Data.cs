using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yad2Project.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Yad2Project.Data
{
    public class Yad2Data :  IdentityDbContext<User,IdentityRole<long>,long> // DbContext
    {

       
        //public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }


        public Yad2Data(DbContextOptions<Yad2Data> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
          new User
          {
              Id = 1,
              FirstName = "Tamar",
              LastName = "Elen",
              BirthDate = new DateTime(1990, 1, 1),
              Email = "t@gmail.com",
              UserName = "TE",
              Password = "111"
          },
              new User
              {
                  Id = 2,
                  FirstName = "Maria",
                  LastName = "Eden",
                  BirthDate = new DateTime(1989, 1, 1),
                  Email = "m@gmail.com",
                  UserName = "ME",
                  Password = "111",

              });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                   //Images[0] = new ImageInfo(),
                    //{
                    ImageMimeType = "image/jpeg",
                    ImageName = "1.jpg",
                    //},
                    Id = 1,
                    OwnerId = 2,
                 
                    Title = "Judo suit",
                    ShortDescription = "Jodo white suit",
                    LongDescription = "jodo suit size Large",
                    Date = DateTime.Today,
                    Price = 20,
                    //    Images[0]  = new ImageInfo(new IFormFile(),
 
                    State = 1
                }   ,
                
                new Product
                {
                   //Images[0] = new ImageInfo(),
                    //{
                    ImageMimeType = "image/jpeg",
                    ImageName = "2.jpg",
                    //},
                    Id = 2,
                    OwnerId = 2,
                    
                    Title = "Alovera",
                    ShortDescription = "medical alovera",
                    LongDescription = "Small planter of Medical Alovera",
                    Date = DateTime.Today,
                    Price = 20,
                    //    Images[0]  = new ImageInfo(new IFormFile(),
 
                    State = 1
                }         
                
                );
        } //of OnModelCreating
    } //of class Yad2Data
}
