using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace FinalYearProjet.Models
{
    public class RestaurentMenu
    {
        public string RestaurentID { get; set; }
        public int MenuID { get; set; }

        public string NameOfItem { get; set; }

        public string Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile Photo2 { get; set; }
        public string PhotoPATH2 { get; set; }
        public string unit { get; set; }


    }
}
