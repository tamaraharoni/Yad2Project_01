using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yad2Project.Models;

namespace Yad2Project.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        bool DeleteProduct(int id);
        void SaveChanges();
        IQueryable<User> PopulateUsersDropDownList();
    }
}
