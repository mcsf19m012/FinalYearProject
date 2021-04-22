using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalYearProjet.Models
{
    public class ViewModel
    {
        public IEnumerable<RestaurentMenu> restaurents { get; set; }
        public RestaurentMenu rm { get; set; }
    }
}
