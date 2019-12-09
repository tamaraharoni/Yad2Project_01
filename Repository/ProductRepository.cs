using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yad2Project.Data;
using Yad2Project.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace Yad2Project.Repository
{
    public class ProductRepository : IProductRepository
    {
        private Yad2Data _context;
        public ProductRepository(Yad2Data context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public void CreateProduct(Product p)
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    //if any picture is being supplied with parameter p, update its proprties
            //    if (p.Images[i] != null)
            //    {
            //        if (p.Images[i].PhotoAvatar != null && p.Images[i].PhotoAvatar.Length > 0)
            //        {
            //            p.Images[i].ImageMimeType = p.Images[i].PhotoAvatar.ContentType;
            //            p.Images[i].ImageName = p.Images[i].PhotoAvatar.FileName;
            //            using (MemoryStream stream = new MemoryStream())
            //            {
            //                p.Images[i].PhotoAvatar.CopyTo(stream);
            //                p.Images[i].PhotoFile = stream.ToArray();
            //            }
            //        }
            //    }
            //}

            if (p.PhotoAvatar != null && p.PhotoAvatar.Length > 0)
            {
                p.ImageMimeType = p.PhotoAvatar.ContentType;
                p.ImageName = Path.GetFileName(p.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    p.PhotoAvatar.CopyTo(memoryStream);
                    p.PhotoFile = memoryStream.ToArray();
                }
              
            }
            _context.Add(p);
            _context.SaveChanges();
        }
        public bool DeleteProduct(int id)
        {
            var ProdToBeDeleted = _context.Products.SingleOrDefault(p => p.Id == id);
            if (ProdToBeDeleted != null)
            {
                _context.Remove(ProdToBeDeleted);
                _context.SaveChanges();
                return true;
            }
            return false;



        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }



        public IQueryable<User> PopulateUsersDropDownList()
        {
            var UsersQuery = from u in _context.Users
                             orderby u.UserName
                             select u;
            return UsersQuery;
        }
    }
}
