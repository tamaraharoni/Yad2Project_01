using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yad2Project.Models;
using Yad2Project.Repository;

namespace Yad2Project.Controlers
{
    public class AccountController : Controller
    {

        private IUserRepository _repository;

        public AccountController()//IUserRepository repository)
        {
            //_repository = repository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Login(LoginVM model)
        //{

        //    User user = _repository.GetUserByUserName(model.UserName);

        //   if(user != null && user.Password == model.Password) 
        //    {
        //        ViewBag.User = model.UserName;
        //        ViewBag.UserIsAdmin = user.IsAdmin;
        //        return RedirectToAction("Index", "Products");
        //    }
        //    else
        //    {
        //        ViewBag.Error = "Wrong User name or password";
        //        return View();
        //    }
        //}
    }
}