using ASPNETCOREMVC.Data;
using ASPNETCOREMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Controllers
{
    public class ShoppingPaymentController : Controller
    {
        private readonly MovieDbContext _context;

        public ShoppingPaymentController(MovieDbContext context)
        {
            _context = context;
        }

        public IActionResult ShoppingCartOverview()
        {
            List<Movie> movieList = new List<Movie>();

            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    movieList = InitializeShoppingCart();
                }
            }

            return View(movieList);
        }

        private List<Movie> InitializeShoppingCart()
        {
            List<Movie> movieList = new List<Movie>();

            string shoppingCartJsonString = HttpContext.Session.GetString("ShoppingCart");
            List<int> ids = JsonSerializer.Deserialize<List<int>>(shoppingCartJsonString);


            foreach(int currentArticleId in ids)
            {
                Movie currentMovie = _context.Movie.Find(currentArticleId);
                movieList.Add(currentMovie);
            }



            return movieList;

        }


        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            List<Movie> movies = InitializeShoppingCart();

            //Wird geprüft, ob die ArtikelId sich im Warenkorb befindet
            if (movies.Any(a => a.Id == id.Value))
            {
                Movie toCancel = movies.First(a => a.Id == id.Value);

                movies.Remove(toCancel);

                if (movies.Count == 0)
                {
                    HttpContext.Session.Remove("ShoppingCart");
                }
                else
                {
                    string jsonString = JsonSerializer.Serialize(movies.Select(n => n.Id).ToList());

                    HttpContext.Session.SetString("ShoppingCart", jsonString);
                }
            }

            return RedirectToAction(nameof(ShoppingCartOverview));
        }


        public IActionResult Payment()
        {
            return View();
        }


        //[AllowAnonymous] //In dieser Methode dürfen alle User oder Unbekannte darauf zugreifen
        //public IActionResult AllCanAccess()
        //{
        //    return View();
        //}

        //[Authorize("Admins")]
        //[Authorize("Support")]
        //public IActionResult OnlyAdmins()
        //{
        //    return View();
        //}


    }
}
