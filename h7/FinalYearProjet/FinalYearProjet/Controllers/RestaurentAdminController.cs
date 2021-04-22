using FinalYearProjet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FinalYearProjet.Controllers
{
    public class RestaurentAdminController : Controller
    {
        private readonly IHostingEnvironment hostingEnviroment;
        public RestaurentAdminController(IHostingEnvironment hostingEnviroment)
        {
            this.hostingEnviroment = hostingEnviroment;
        }
        public ViewResult Delete(string RestaurentID)
        {
            Restaurent r = RestaurentRepository.restaurents.Find(r => r.RestaurentID == RestaurentID);
            RestaurentRepository.restaurents.Remove(r);
            RestaurentRepository.RemoveRestaurent(RestaurentID);
            RestaurentMenu rm = RestaurentRepository.restaurentsMenu.Find(r => r.RestaurentID == RestaurentID);
          
            if (rm!=null)
            {
                RestaurentRepository.restaurentsMenu.Remove(rm);
                RestaurentRepository.RemoveMenu(RestaurentID, rm.MenuID);
            }
            
            return View("ViewRestaurent", RestaurentRepository.restaurents);

        }
        public ViewResult DeleteItem(string RestaurentID)
        {
            RestaurentMenu r = RestaurentRepository.restaurentsMenu.Find(r => r.RestaurentID == RestaurentID);
            RestaurentRepository.restaurentsMenu.Remove(r);
            RestaurentRepository.RemoveMenu(RestaurentID, r.MenuID);
            return View("ViewRestaurentMenue", RestaurentRepository.restaurentsMenu);

        }
        public ViewResult Index()
        {
            return View("AddRestaurent");
        }

        [HttpGet]
        public ViewResult AddRestaurent()
        {
            return View("AddRestaurent");
        }
        [HttpPost]
        public ViewResult AddRestaurent(Restaurent r)
        {
            string uNIQfileName = null;

            if (r.Photo != null)
            {
                var uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "RestaurentImages");

                uNIQfileName = Guid.NewGuid().ToString() + "_" + r.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uNIQfileName);
                r.Photo.CopyTo(new FileStream(filePath, FileMode.Create));


            }
            
          
            r.PhotoPATH = uNIQfileName;

            RestaurentRepository.AddRestaurent(r);
            
            return View("AddRestaurent");

        }
        [HttpGet]
        public ViewResult ViewRestaurent(Restaurent r)
        {
            return View(RestaurentRepository.restaurents);
        }
        [HttpGet]
        public ViewResult ViewRestaurentMenue()
        {
            return View(RestaurentRepository.restaurentsMenu);
        }
        [HttpGet]
        public ViewResult Edit(string RestaurentID)
        {
            Restaurent r = RestaurentRepository.restaurents.Find(r => r.RestaurentID == RestaurentID);

            return View("Edit", r);
        }
        [HttpPost]

        public ViewResult Edit(Restaurent r)
        {
            if (ModelState.IsValid)
            {
                foreach (Restaurent restaurent in RestaurentRepository.restaurents)
                {
                    string uNIQfileName = null;

                    if (restaurent.RestaurentID == r.RestaurentID)
                    {
                        restaurent.NameOfRestaurants = r.NameOfRestaurants;
                        restaurent.Location = r.Location;
                        restaurent.PhoneNo = r.PhoneNo;
                        restaurent.OpenUntil = r.OpenUntil;
                        restaurent.DeliveryCharges = r.DeliveryCharges;
                        if(r.Password==null)
                        {
                            Restaurent r2 = RestaurentRepository.restaurents.Find(r2 => r2.RestaurentID == r.RestaurentID);
                            //uNIQfileName = r2.PhotoPAT;
                            r.Password= r2.Password;
                        }
                        restaurent.Password = r.Password;
                        
                        if(r.PhotoPATH==null)
                        {
                            Restaurent r2 = RestaurentRepository.restaurents.Find(r2 => r2.RestaurentID ==r.RestaurentID);
                            uNIQfileName = r2.PhotoPATH;
                            r.Photo = r2.Photo;
                        }
                        if (r.Photo != null)
                        {
                            var uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "RestaurentImages");

                            uNIQfileName = Guid.NewGuid().ToString() + "_" + r.Photo.FileName;
                            string filePath = Path.Combine(uploadFolder, uNIQfileName);
                            r.Photo.CopyTo(new FileStream(filePath, FileMode.Create));


                        }


                        r.PhotoPATH = uNIQfileName;
                        restaurent.PhotoPATH = uNIQfileName;

                        break;
                    }

                }
                RestaurentRepository.EditRestaurent(r);
                return View("ViewRestaurent", RestaurentRepository.restaurents);

            }
            else
            {
                ModelState.AddModelError(string.Empty, "please enter correct data");
                return View();
            }

        }
        [HttpGet]
        public ViewResult AddMenu(string RestaurentID)
        {
            RestaurentMenu rm =new RestaurentMenu();
            rm.RestaurentID = RestaurentID;


            return View("AddRestaurentMenue",rm);

        }
        [HttpPost]
        public ViewResult AddMenu(RestaurentMenu rm)
        {
            string uNIQfileName = null;

            if (rm.Photo2 != null)
            {
                var uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "MenueImages");

                uNIQfileName = Guid.NewGuid().ToString() + "_" + rm.Photo2.FileName;
                string filePath = Path.Combine(uploadFolder, uNIQfileName);
                rm.Photo2.CopyTo(new FileStream(filePath, FileMode.Create));


            }


            rm.PhotoPATH2 = uNIQfileName;

            RestaurentRepository.AddRestaurentMenu(rm);
            return View("ViewRestaurentMenue", RestaurentRepository.restaurentsMenu);
        }
        [HttpGet]
        public ViewResult EditItem(string RestaurentID, int MenuID)
        {
            RestaurentMenu r = RestaurentRepository.restaurentsMenu.Find(r => r.RestaurentID == RestaurentID && r.MenuID ==MenuID);

            return View("EditMenue", r);
        }
        [HttpPost]

        public ViewResult EditItem(RestaurentMenu rm)
        {
            if (ModelState.IsValid)
            {
                foreach (RestaurentMenu restaurentmenu in RestaurentRepository.restaurentsMenu)
                {
                    string uNIQfileName = null;

                    if (restaurentmenu.RestaurentID == rm.RestaurentID)
                    {
                        restaurentmenu.RestaurentID = rm.RestaurentID;
                        restaurentmenu.NameOfItem = rm.NameOfItem;

                        restaurentmenu.Price = rm.Price;
                        restaurentmenu.Quantity = rm.Quantity;
                        restaurentmenu.unit = rm.unit;
                        if (rm.PhotoPATH2 == null)
                        {
                            RestaurentMenu r2 = RestaurentRepository.restaurentsMenu.Find(r2 => r2.RestaurentID == rm.RestaurentID && r2.MenuID == rm.MenuID);
                            uNIQfileName = r2.PhotoPATH2;
                            rm.Photo2 = r2.Photo2;
                        }
                        if (rm.Photo2 != null)
                        {
                            var uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "MenueImages");

                            uNIQfileName = Guid.NewGuid().ToString() + "_" + rm.Photo2.FileName;
                            string filePath = Path.Combine(uploadFolder, uNIQfileName);
                            rm.Photo2.CopyTo(new FileStream(filePath, FileMode.Create));


                        }
                        rm.PhotoPATH2 = uNIQfileName;
                        restaurentmenu.PhotoPATH2 = uNIQfileName;

                        
                        break;
                    }

                }
                RestaurentRepository.EditMenu(rm);
                return View("ViewRestaurentMenue", RestaurentRepository.restaurentsMenu);

            }
            else
            {
                ModelState.AddModelError(string.Empty, "please enter correct data");
                return View();
            }

        }
    }
}
