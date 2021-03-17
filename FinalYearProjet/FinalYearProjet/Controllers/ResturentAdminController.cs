using FinalYearProjet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalYearProjet.Controllers
{
    public class ResturentAdminController : Controller
    {
        
        [HttpGet]
        public ViewResult AddRestaurent()
        {
            return View("AddRestaurent");
        }
        [HttpPost]
        public ViewResult AddRestaurent(Restaurent r)
        {
            RestaurentRepository.AddRestaurent(r);
            return View("AddRestaurent");

        }
    }
}
