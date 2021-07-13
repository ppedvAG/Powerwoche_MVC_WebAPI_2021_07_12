using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Controllers
{
    public class FormularDemoController : Controller
    {


        [HttpGet]
        public IActionResult Sample1() //Zeigt das Formular
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sample1(string myText, int myNumber) //Parametervarialen müssen den selbe Benennung aufweisen, wie in  <input>-Tag - Attribut Name: 
        {

            return RedirectToAction("Sample2", new { myText = myText, myNumber = myNumber } );
        }


        public IActionResult Sample2(string myText, int MyNumber)
        {
            MyLinkValues myValues = new MyLinkValues();
            myValues.Name = myText;
            myValues.Zahl = MyNumber;

            return View(myValues);
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firstName, string lastName)
        {
            ViewBag.Name = string.Format("Name: {0} {1}", firstName, lastName);
            return RedirectToAction("Index");
        }


        public IActionResult Sample3 ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAny(string myText, int MyNumber)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DoAnything(string myText, int MyNumber)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sample3(string myText, int myNumber) //Parametervarialen müssen den selbe Benennung aufweisen, wie in  <input>-Tag - Attribut Name: 
        {

            return RedirectToAction("Sample2", new { myText = myText, myNumber = myNumber });
        }
    }


    public class MyLinkValues
    {
        public string Name { get; set; }
        public int Zahl { get; set; }
    }
}
