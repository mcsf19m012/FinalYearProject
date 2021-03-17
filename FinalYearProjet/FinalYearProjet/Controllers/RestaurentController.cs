using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalYearProjet.Controllers
{
    public class RestaurentController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public ViewResult RestaurentHomePage()
        {

            return View("RestaurentHomePage");
        }
        [HttpGet]
        public ViewResult RestaurentMenue()
        {

            return View("RestaurentMenue");
        }
        public ViewResult RestaurentList()
        {

            return View("RestaurentList");
        }
        public ViewResult RestaurentCartView()
        {

            return View("RestaurentCartView");
        }
    }
}
