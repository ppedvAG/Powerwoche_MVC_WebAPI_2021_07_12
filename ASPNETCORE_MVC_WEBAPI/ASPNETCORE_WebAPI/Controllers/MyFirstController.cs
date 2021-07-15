using ASPNETCORE_WebAPI.Data;
using ASPNETCORE_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Controllers
{
    [Route("api/[controller]")] //URI
    [ApiController] 
    [Produces("application/json")] //Produces ist ein Filter, der die Formatrückgabe auf application/json definiert.
    //Alle Methoden liefern das Format application/json zurück
    
    public class MyFirstController : ControllerBase
    {
        private readonly MovieDbContext _ctx;

        public MyFirstController(MovieDbContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Eine Einfache Synchrone Methode
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAll()
        {
            return _ctx.Movies.ToList();
        }
    }
}
