using ASPNETCOREMVC.Models;
using ASPNETCOREMVC.ViewModels;
using DependencyInversionSample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Controllers
{
    public class DemoController : Controller
    {
        private readonly IMockCar _car;

        public DemoController(IMockCar car)
        {
            _car = car;
        }

        public IActionResult Sample1()
        {
            return View(_car);
        }

        public IActionResult Sample2()
        {
            Product product = new Product()
            {
                Id = 123,
                Name = "Haribo",
                Preis = 11.99m
            };

            return View(product);
        }

        public IActionResult Sample3()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Playstation 5",
                    Preis = 499.95m
                },
                new Product()
                {
                    Id = 2,
                    Name = "XBox",
                    Preis = 199m
                },
                new Product()
                {
                    Id = 3,
                    Name = "Nitendo Switch",
                    Preis = 300m
                }
            };

            return View(products);
        }

        //Diese MEthode ist nur mit ID verwendbar
        public IActionResult Sample4(int? id)
        {

            if (!id.HasValue)
                return NotFound(); //404 Fehler wird ausgegeben, wenn die Id Leer ist 

            Product product = new Product()
            {
                Id = id.Value,
                Name = "Haribo",
                Preis = 11.99m
            };

            return View(product);
        }

        public IActionResult SampleWithViewModel()
        {
            RegisseurStatVM regisseurStat = new RegisseurStatVM();

            if (regisseurStat.Regisseur == null)
                regisseurStat.Regisseur = new Regisseur();

            regisseurStat.Regisseur.Id = 123;
            regisseurStat.Regisseur.Name = "Steven Spielberg";

            regisseurStat.MovieList = new List<Movie>();
            regisseurStat.MovieList.Add(new Movie
            {
                Id = 1,
                Title = "ES",
                Description = "Film mit Clown",
                Price = 12.99m
            });
            regisseurStat.MovieList.Add(new Movie
            {
                Id = 2,
                Title = "Jurassic Park",
                Description = "Bitte nicht den T-Rex selbständig füttern",
                Price = 13.99m
            });
            regisseurStat.MovieList.Add(new Movie
            {
                Id = 3,
                Title = "Donald Duck",
                Description = "Abenteuer in Entenhausen",
                Price = 2.99m
            });

            regisseurStat.FouvriteActos = new List<Actors>();
            regisseurStat.FouvriteActos.Add(new Actors()
            {
                Id = 1,
                Name = "Cameron Diaz"
            });
            regisseurStat.FouvriteActos.Add(new Actors()
            {
                Id = 2,
                Name = "Brad Pitt"
            });

            return View(regisseurStat);
        }


        public IActionResult RoutValuesWithQueryStringSample()
        {
            return View();
        }

        //Call mit QueryString -> https://localhost:5001/Demo/QueryStringDemo?id=1&name=harry
        public IActionResult QueryStringDemo(int? id, string name)
        {
            return View();
        }


        [Route("sample5/{fullName}/{zahldesTages}")]
        public IActionResult Sample5(string fullName, int zahldesTages)
        {
            return View();
        }
    }
}
