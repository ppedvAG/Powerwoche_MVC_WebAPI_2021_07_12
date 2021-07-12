using ASPNETCOREMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.ViewModels
{
    public class RegisseurStatVM
    {
        public Regisseur Regisseur { get; set; }
        public IList<Movie> MovieList { get; set; }

        public IList<Actors> FouvriteActos { get; set; }
    }
}
