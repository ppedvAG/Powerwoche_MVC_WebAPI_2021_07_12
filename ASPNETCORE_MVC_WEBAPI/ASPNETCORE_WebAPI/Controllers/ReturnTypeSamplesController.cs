using ASPNETCORE_WebAPI.Data;
using ASPNETCORE_WebAPI.Data.Repository;
using ASPNETCORE_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypeSamplesController : ControllerBase
    {
        private readonly MovieDbContext _ctx;


        private readonly ProductsRepository _repository;

        public ReturnTypeSamplesController(MovieDbContext ctx, ProductsRepository repository)
        {
            _ctx = ctx;
            _repository = repository;
        }


        [HttpGet("syncsale")] 
        //Synchroner Rückgabe Stream
        public IEnumerable<Movie> GetOnSaleProducts()
        {
            var movies = _ctx.Movies.ToList();

            foreach (Movie currentMovie in movies)
            {
                yield return currentMovie;
            }
        }

        #region snippet_GetOnSaleProductsAsync
        [HttpGet("asyncsale")]
        public async IAsyncEnumerable<Product> GetOnSaleProductsAsync()
        {
            var products = _repository.GetProductsAsync();

            await foreach (var product in products)
            {
                if (product.IsOnSale)
                {
                    yield return product;
                }
            }
        }
        #endregion





        #region asynchrone Methoden + CreatedAtAction -> Beispiel gibt ein angelegtes Movie Object mit Id-Key zurück


        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovieAsync(Movie movie)
        {
            if (_ctx.Movies.Any(m=>m.Title.Contains("XYZ Widget")))
            {
                return BadRequest();
            }


            await _ctx.Movies.AddAsync(movie);
            await _ctx.SaveChangesAsync();

            //CreatedAtActionResult(nameof(GetById), "Products", new { id = product.Id }, product);.
            //
            // In diesem Codepfad wird das Product-Objekt im Antworttext bereitgestellt.
            // Ein Location-Antwortheader, der die neu erstellte Produkt - URL enthält, wird bereitgestellt.


            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        [HttpGet("GetById/{id}")]
        public Movie GetById(int id)
        {
            return _ctx.Movies.Find(id);
        }



        #endregion

    }
}
