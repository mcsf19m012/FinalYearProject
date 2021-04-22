using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalYearProjet.Models;


namespace FinalYearProjet.Controllers
{
    public class RestaurentController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public ViewResult UserSignUp()
        {
            return View("UserSignUp");

        }
        [HttpPost]
        public ViewResult UserSignUp(User u)
        {

            if (ModelState.IsValid)
            {
                foreach (User u1 in RestaurentRepository.user)
                {
                    if (u1.UserID == u.UserID)
                    {
                        ModelState.AddModelError(string.Empty, "Login already exist");
                        return View("UserSignUp");
                    }
                }
                //RestaurentRepository.AddRestaurent(r);
                //RestaurentRepository.SetRestaurentId(r.RestaurentID);
                //ViewBag.r = r;
                return View("RestaurentHomePage");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "please enter correct data");
                return View("UserSignUp");
            }

        }
        [HttpGet]
        public ViewResult RestaurentHomePage()
        {

            return View("RestaurentHomePage");
        }
        [HttpGet]
        public ViewResult RestaurentMenue(string RestaurentID)
        {
            RestaurentRepository.SetRestaurentId(RestaurentID);
            return View("RestaurentMenue", RestaurentRepository.restaurentsMenu);
            //RestaurentMenu rm = RestaurentRepository.restaurentsMenu.Find(r => r.RestaurentID == RestaurentID);


        }
        //[HttpPost]
        //public ViewResult RestaurentMenue(RestaurentMenu rm)
        //{
        //    return View("RestaurentMenue", RestaurentRepository.restaurentsMenu);
        //}
        [HttpGet]
        public ViewResult RestaurentList()
        {
            

            return View("RestaurentList", RestaurentRepository.restaurents);
        }
      
             [HttpGet]
        public ViewResult Back()
        {
            RestaurentRepository.REmoveRestaurentId();

            return View("RestaurentList", RestaurentRepository.restaurents);
        }
        [HttpGet]
        public ViewResult RestaurentCartView()
        {

            return View("RestaurentCartView");
        }
        [HttpGet]
        public ViewResult RestaurentContactUs()
        {
            return View("RestaurentContactUs");
        }
        [HttpGet]
        public ViewResult MenueDetail(string RestaurentID, int MenuID)
        {
            RestaurentMenu rm = RestaurentRepository.restaurentsMenu.Find(rm => rm.RestaurentID == RestaurentID && rm.MenuID == MenuID);
           
            return View("MenueDetail",rm);
        }
      
    }
}
