using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Yad2Project.Repository;
using Yad2Project.Models;
using System.IO;
using Yad2Project.Models.VM;

namespace Yad2Project.Controlers
{
    public class ProductsController : Controller
    {
        IProductRepository _repository;
        IHostingEnvironment _environment;

        public ProductsController(IProductRepository repository,IHostingEnvironment enviroment)
        {
            _repository = repository;
            _environment = enviroment;
        }


        public IActionResult Index()
        {
            IEnumerable<Yad2Project.Models.VM.ProductVM> products = _repository.GetProducts()
                .Select(x => new ProductVM()
            {
                 Id=x.Id,
                 Date = x.Date,
                  Owner =  x.Owner,
                  Title  =x.Title,
                  ShortDescription = x.ShortDescription,
                  LongDescription = x.LongDescription,
                  Price = x.Price,
                  State = x.State,
                  PhotoAvatar = x.PhotoAvatar,
                  ImageName = x.ImageName
              
            });
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _repository.GetProducts().SingleOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }



        [HttpGet]
        public IActionResult Create()
        {
          //  PopulateUsersDropDownList();
            return View();
        }
      
                [HttpPost, ActionName("Create")]
                public IActionResult Create(Product product)
                {
                    if (ModelState.IsValid)
                    {
                        product.Date = DateTime.Today;
                         product.State = 0;
                        _repository.CreateProduct(product);
                        return RedirectToAction(nameof(Index));
                    }
                    //PopulateUsersDropDownList(product.OwnerId);
                    return View(product);
                }

      
                      [HttpGet]
                      public IActionResult Edit(int id)
                      {
            //Cupcake cupcake = _repository.GetCupcakeById(id);
            //if (cupcake == null)
            //{
            //    return NotFound();
            //}
            //PopulateBakeriesDropDownList(cupcake.BakeryId);
            //return View(cupcake);
            return View();
                      }

        /*
               * 
               * 
               * 
               * 
               [HttpPost, ActionName("Edit")]
                      public async Task<IActionResult> EditPost(int id)
                      {
                          var cupcakeToUpdate = _repository.GetCupcakeById(id);
                          bool isUpdated = await TryUpdateModelAsync<Cupcake>(
                                              cupcakeToUpdate,
                                              "",
                                              c => c.BakeryId,
                                              c => c.CupcakeType,
                                              c => c.Description,
                                              c => c.GlutenFree,
                                              c => c.Price);
                          if (isUpdated)
                          {
                              _repository.SaveChanges();
                              return RedirectToAction(nameof(Index));
                          }
                          PopulateBakeriesDropDownList(cupcakeToUpdate.BakeryId);
                          return View(cupcakeToUpdate);
                      }
                       */

        [HttpGet]
                      public IActionResult Delete(int id)
                      {
                          var product = _repository.GetProductById(id);
                          if (product == null)
                          {
                              return NotFound();
                          }
                          return View(product);
                      }

                      [HttpPost, ActionName("Delete")]
                      public IActionResult DeleteConfirmed(int id)
                      {
                          _repository.DeleteProduct(id);
                          return RedirectToAction(nameof(Index));
                      }


        //private void PopulateUsersDropDownList(int? selectedUser = null)
        //{
        //    var Users = _repository.PopulateUsersDropDownList();
        //    ViewBag.OwnerID = new SelectList(Users.AsNoTracking(), "OwnerId", "Owner Name", selectedUser);
          
        //}















        public IActionResult GetImage(int id)
        {
            Product requestedProduct = _repository.GetProductById(id);
            if (requestedProduct != null)
            {
                string webRootpath =   _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedProduct.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedProduct.ImageMimeType);
                }
                else
                {
                    if (requestedProduct.PhotoFile.Length > 0)
                    {
                        return File(requestedProduct.PhotoFile, requestedProduct.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}