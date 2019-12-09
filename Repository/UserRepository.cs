using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yad2Project.Data;
using Yad2Project.Models;

namespace Yad2Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private Yad2Data _context;

        public UserRepository(Yad2Data context)
        {
            _context = context;
        }

        public void CreateUser(User product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }


        public User GetUserByUserName(string userName)
        {
            return _context.Users.Where(m => m.UserName == userName).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }


    }
}
