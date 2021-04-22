using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using FinalYearProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace FinalYearProjet.Controllers
{
    public class UserController : Controller

    {
        private readonly IHostingEnvironment hostingEnviroment;
        public UserController(IHostingEnvironment hostingEnviroment)
        {
            this.hostingEnviroment = hostingEnviroment;
        }

       

        [HttpGet]
        public ViewResult Login()
        {
            RestaurentRepository.REmoveRestaurentId();
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
          
            foreach (Restaurent r in RestaurentRepository.restaurents)
            {
                
                if ((r.RestaurentID == u.UserID) && (r.Password == u.Password))
                {
                    ViewBag.r = r;
                    RestaurentRepository.SetRestaurentId(r.RestaurentID);
                    //TempData["mydata"] = r.RestaurentID;
                    return RedirectToAction("ownerHomePage" ,"RestaurentOwner",r.RestaurentID);
           
                }
            }
            return RedirectToAction("~/Views/Restaurent/RestaurentHomePage.cshtml");
        }
    }
}
