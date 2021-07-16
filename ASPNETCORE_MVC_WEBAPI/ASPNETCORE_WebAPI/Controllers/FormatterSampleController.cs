using ASPNETCORE_WebAPI.Data;
using ASPNETCORE_WebAPI.Data.Repository;
using ASPNETCORE_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatterSampleController : ControllerBase
    {
        private readonly MovieDbContext _ctx;


        private readonly ProductsRepository _repository;

        public FormatterSampleController(MovieDbContext ctx, ProductsRepository repository)
        {
            _ctx = ctx;
            _repository = repository;
        }

       

        [HttpGet("GetAllMovies")] //content-type: application/json; charset=utf-8 
        public List<Movie> GetAll()
        {
            return _ctx.Movies.ToList();
        }


        [HttpGet("GetMoviesById/{Id}")]
        public Movie GetById (int Id)
        {
            return _ctx.Movies.Find(Id);
        }




        [HttpGet("GetMovieString")] //Rückgabe Format: content-type: text/plain; charset=utf-8 
        public string GetMovieString()
        {
            Movie currentMovie = _ctx.Movies.First();
            string output = $"Id: {currentMovie.Id} Name: {currentMovie.Title}";

            return output;
        }


        // GET api/FormatterSample/About 
        [HttpGet("About")] //Rückgabe Format: content-type: text/plain; charset=utf-8 
        public ContentResult About()
        {
            return Content("An API listing authors of docs.asp.net.");
        }


        #region ContentNegotations (Inhaltsaushandlung)
        #endregion

        [HttpGet("Search")]
        //Call -> https://localhost:5001/api/FormatterSample/Search?namelike=Star
        public IActionResult Search(string namelike)
        {
            var result = _ctx.Movies.Where(m => m.Title.Contains(namelike)).ToList();

            if (!result.Any())
            {
                return NotFound(namelike);
            }
            return Ok(result);
            //content-type: application/json; charset=utf-8 
        }


        [HttpGet("error")]
        public IActionResult GetError()
        {
            return Problem("Something went wrong!");
        }




        #region Zuordnung des Antwortformats durch URLs

        ///api/FormatterSample/5	  Standard-Ausgabeformatierungsprogramm
        ///api/FormatterSample/5.json JSON-Formatierungsprogramm (falls konfiguriert)
        //api/FormatterSample/5.xml   XML-Formatierungsprogramm  (falls konfiguriert

        [HttpGet("{id}.{format?}")]
        public Product Get(int id)
        {


            return new Product();
        }
        #endregion

    }
}
