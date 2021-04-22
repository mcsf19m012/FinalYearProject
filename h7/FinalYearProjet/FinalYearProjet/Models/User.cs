using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FinalYearProjet.Models
{
    public class User
    {
        [DataType(DataType.EmailAddress)]
        public string UserID { get; set; }
        public string Password { get; set; }

    }
}
