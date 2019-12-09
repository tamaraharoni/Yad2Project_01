using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yad2Project.Models;

namespace Yad2Project.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User GetUserByUserName(string userName);
        void CreateUser(User product);
        bool DeleteUser(int id);
        void SaveChanges();
    }
}
