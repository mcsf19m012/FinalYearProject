using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FinalYearProjet.Models
{
    public class Order
    {
        [DataType(DataType.EmailAddress)]
        public string RestaurentID { get; set; }
        [DataType(DataType.EmailAddress)]
        public string UserID { get; set; }
        public int MenuID { get; set; }
        public string NameOfItem { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }

        public Boolean OrderAccept { get; set; }
        public Boolean OrderReceived { get; set; }


    }
}
