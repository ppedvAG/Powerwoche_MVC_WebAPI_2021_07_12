using ASPNETCORE_WebAPI.Data;
using ASPNETCORE_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [ApiConventionType(typeof(DefaultApiConventions))] //Microsoft.AspNetCore.Mvc.ApiConventionTypeAttribute, auf einen Controller angewendet — Wendet den angegebenen Konventionstyp auf alle Controlleraktionen an.Eine Konventionsmethode ist mit Hinweisen markiert, mit denen die Aktionen bestimmt werden, für die die Konventionsmethode gilt.Weitere Informationen zu Hinweisen finden Sie unter Erstellen von Web-API-Konventionen).

    public class ConventionsController : ControllerBase
    {
        private readonly MovieDbContext _ctx;

        public ConventionsController(MovieDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] //ProducesResponseType sagt, welche Http-Status Codes eine Methode ausgeben kann
        [ProducesResponseType(StatusCodes.Status303SeeOther)] //Geben an, dass in dieser Methode auch eine Umleitung eingebaut ist
        public List<Movie> GetAll()
        {
            return _ctx.Movies.ToList();
        }

        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public Movie Find([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)] int id)
        {
            Movie movie = _ctx.Movies.Find(id);

            if (movie == null)
                return null;

            return movie;
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public void AddMovie(Movie movie)
        {
            _ctx.Movies.Add(movie);
            _ctx.SaveChanges();
        }

        [HttpPut("id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public void UpdateMovie(int id, Movie movie)
        {

            if (id != movie.Id)
            {
                //werden später erfahren, wie wir mit solchen Fällem umgehen können
            }

            var tempMovie = _ctx.Movies.Find(id);

            if (tempMovie == null)
            {
                //werden später erfahren, wie wir mit solchen Fällem umgehen können
            }

            _ctx.Update(movie);
            _ctx.SaveChanges();
        }

    }
}
