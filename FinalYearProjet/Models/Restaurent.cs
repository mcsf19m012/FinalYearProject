using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalYearProjet.Models
{
    public class Restaurent
    {
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50)]
        public string NameOfRestaurants { get; set; }

        public string Location { get; set; }


        public string PhoneNo { get; set; }


        public string OpenUntil { get; set; }

        public string DeliveryCharges { get; set; }

        // public string PhotoPATH { get; set; }

        //  public IFormFile Photo { get; set; }
    }
}
