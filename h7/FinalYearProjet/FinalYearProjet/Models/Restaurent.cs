using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace FinalYearProjet.Models
{
    public class Restaurent
    {
        [DataType(DataType.EmailAddress)]
        
        public string RestaurentID { get; set; }
        //[Required(ErrorMessage = "please enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50)]
        public string NameOfRestaurants { get; set; }
        [Required(ErrorMessage = "Please enter Adress")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter No")]
        public string PhoneNo { get; set; }


        public string OpenUntil { get; set; }

        public string DeliveryCharges { get; set; }



        public string PhotoPATH { get; set; }

        public IFormFile Photo { get; set; }

    }
}
