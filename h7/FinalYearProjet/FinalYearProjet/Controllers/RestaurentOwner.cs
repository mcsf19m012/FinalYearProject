using FinalYearProjet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalYearProjet.Controllers
{
    public class RestaurentOwner : Controller
    {
        private readonly IHostingEnvironment hostingEnviroment;
        public RestaurentOwner(IHostingEnvironment hostingEnviroment)
        {
            this.hostingEnviroment = hostingEnviroment;
        }
        [HttpGet]
        public ViewResult OrderList()
        {
            return View("OrderList");
        }



        [HttpGet]
        public ViewResult ownerHomePage(string RestaurentID)
        {
            //if(RestaurentID==null)
            //{
            //    RestaurentID = TempData["mydata"] as String;
            //}
            
            Restaurent r = RestaurentRepository.restaurents.Find(r => r.RestaurentID == RestaurentID);
            ViewBag.r = r;
            return View("ownerHomePage");
        }

        [HttpGet]
        public ViewResult OwnerSignup()
        {
            return View("OwnerSignup");
        }
        [HttpPost]
        public ViewResult OwnerSignup(Restaurent r)
        {
            string uNIQfileName = null;
            if (ModelState.IsValid)
            {
                foreach (Restaurent res in RestaurentRepository.restaurents)
                {
                    if (res.RestaurentID == r.RestaurentID)
                    {
                        ModelState.AddModelError(string.Empty, "Login already exist");
                        return View("OwnerSignup");
                    }
                }

                if (r.Photo != null)
                {
                    var uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "RestaurentImages");

                    uNIQfileName = Guid.NewGuid().ToString() + "_" + r.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uNIQfileName);
                    r.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                }


                r.PhotoPATH = uNIQfileName;

                RestaurentRepository.AddRestaurent(r);
                RestaurentRepository.SetRestaurentId(r.RestaurentID);
                ViewBag.r = r;
                return View("ownerHomePage");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "please enter correct data");
                return View("OwnerSignup");
            }

        }
        [HttpGet]
        public ViewResult PendingOrderList()
        {
            return View("PendingOrderList");
        }

        [HttpGet]
        public ViewResult Profile()
        {
            Restaurent r = RestaurentRepository.restaurents.Find(r => r.RestaurentID == RestaurentRepository.GetRestaurentId());

            return View("Profile", r);
        }
        [HttpPost]

        public ViewResult Profile(Restaurent r)
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
                        if (r.Password == null)
                        {
                            Restaurent r2 = RestaurentRepository.restaurents.Find(r2 => r2.RestaurentID == r.RestaurentID);
                            //uNIQfileName = r2.PhotoPAT;
                            r.Password = r2.Password;
                        }
                        restaurent.Password = r.Password;

                        if (r.PhotoPATH == null)
                        {
                            Restaurent r2 = RestaurentRepository.restaurents.Find(r2 => r2.RestaurentID == r.RestaurentID);
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
                ViewBag.r = r;
                return View("ownerHomePage");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "please enter correct data");
                return View();
            }

        }
        [HttpGet]
        public ViewResult OwnerMenuList()
        {
            return View("OwnerMenuList", RestaurentRepository.restaurentsMenu);
        }
        [HttpGet]
        public ViewResult AddMenu()
        {
            RestaurentMenu rm = new RestaurentMenu();
            rm.RestaurentID = RestaurentRepository.GetRestaurentId();


            return View("AddMenu", rm);

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
            return View("OwnerMenuList", RestaurentRepository.restaurentsMenu);
        }
        public ViewResult DeleteItem(string RestaurentID)
        {
            RestaurentMenu r = RestaurentRepository.restaurentsMenu.Find(r => r.RestaurentID == RestaurentID);
            RestaurentRepository.restaurentsMenu.Remove(r);
            RestaurentRepository.RemoveMenu(RestaurentID, r.MenuID);
            return View("OwnerMenuList", RestaurentRepository.restaurentsMenu);

        }
        [HttpGet]
        public ViewResult EditItem(string RestaurentID, int MenuID)
        {
            RestaurentMenu r = RestaurentRepository.restaurentsMenu.Find(r => r.RestaurentID == RestaurentID && r.MenuID == MenuID);

            return View("EditMenu", r);
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
                return View("OwnerMenuList", RestaurentRepository.restaurentsMenu);

            }
            else
            {
                ModelState.AddModelError(string.Empty, "please enter correct data");
                return View();
            }

        }
        //[HttpGet]
        //public ViewResult Login()
        //{
        //    RestaurentRepository.REmoveRestaurentId();
        //    return View("Login");
        //}

        //[HttpPost]
        //public ViewResult Login(User u)
        //{

        //    foreach (Restaurent r in RestaurentRepository.restaurents)
        //    {
        //        if ((r.RestaurentID == u.UserID) && (r.Password == u.Password))
        //        {
        //            RestaurentRepository.SetRestaurentId(r.RestaurentID);
        //            ViewBag.r = r;
        //            return View("ownerHomePage");
        //        }
        //    }
        //    return View("Login");
        //    //ModelState.AddModelError(string.Empty, "Login not exist");
        //    // return View("RestaurentHomePage", u.UserID);
        //}
    }
}
