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
        /// 
        
        [HttpGet]
        public List<Movie> GetAll()
        {
            return _ctx.Movies.ToList();
        }

        
        
        
        [HttpGet("{id}")]
       
        public Movie GetById(int id)
        {
            Movie movie = _ctx.Movies.Find(id);

            if (movie == null)
                return null;

            return movie;
        }


        //HTTP Verbs können auch kombiniert werden -> ist Swagger komform
        [HttpPost]
        [HttpPut]
        public void AddMoviePost(Movie movie)
        {
            if (movie.Id == default)
            {
                _ctx.Movies.Add(movie);
                _ctx.SaveChanges();
            }
            else
            {
                _ctx.Update(movie);
                _ctx.SaveChanges();
            }
            
        }
    }
}
