using ASPNETCOREMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult ViewDataSample()
        {
            ViewData["abc"] = "Hallo liebe Teilnehmer";
            ViewData["def"] = "Auch das wird mit übergeben";

            return View();
        }

        public IActionResult ViewBagSample()
        {
            ViewBag.GHJ = "Hallo liebe Teilnehmer, ich bin ViewBag, die schlechte Kopie von ViewData";
            return View();
        }


        public IActionResult TempDataSample()
        {
            TempData["EmailAddress"] = "KevinW@ppedv.de";
            TempData["Id"] = 123;
            return View();
        }

        public IActionResult TempDataSecondSample()
        {
            return View();
        }
        public IActionResult TempDataThirdSample()
        {
            return View();
        }


        public IActionResult SessionStart()
        {
            HttpContext.Session.SetInt32("Lottozahlen", 1234567);
            HttpContext.Session.SetString("Lottogewinner", "Alexander aus Wien");

            Person person = new Person("Muster", 32, "Muster@ppedv");


            //Ab ASP.NET Core 3.0 verwenden wird den System.Text.Json; JsonSerializer
            //Vor ASP.NET Core war Newtonsoft - Serialsier verwendet worden. 
            string jsonString = JsonSerializer.Serialize(person);

            return View();
        }

        public IActionResult SessionResult()
        {
            int? lottozahlen = HttpContext.Session.GetInt32("Lottozahlen");
            string name = HttpContext.Session.GetString("Lottogewinner");

            return View();
        }
    }

}
