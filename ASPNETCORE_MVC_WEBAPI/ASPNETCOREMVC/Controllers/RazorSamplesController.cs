using ASPNETCOREMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Controllers
{
    public class RazorSamplesController : Controller
    {
        public IActionResult Index()
        {

            IList<Person> myPersons = new List<Person>();

            myPersons.Add(new Person("Max", 33));
            myPersons.Add(new Person("Moritz", 44));

            return View(myPersons.ToArray());
        }


        public IActionResult HTMLTagHelperSample()
        { 
            return View();
        }

        public IActionResult CustomizeTagHelperSample()
        {
            return View();
        }
    }
}
