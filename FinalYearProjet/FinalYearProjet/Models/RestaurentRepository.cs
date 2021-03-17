using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalYearProjet.Models
{
    public static class RestaurentRepository
    {
        public static List<Restaurent> restaurents = new List<Restaurent>();
        public static void AddRestaurent(Restaurent r)
        {

            restaurents.Add(r);
        }
    }
}
