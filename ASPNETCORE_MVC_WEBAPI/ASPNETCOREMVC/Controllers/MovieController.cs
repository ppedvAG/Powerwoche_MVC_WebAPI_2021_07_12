using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCOREMVC.Data;
using ASPNETCOREMVC.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ASPNETCOREMVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                ViewData["FilterQuery"] = query;
            }

            IList<Movie> filteredList = string.IsNullOrEmpty(query) ?
                await _context.Movie.ToListAsync() :
                await _context.Movie.Where(q => q.Title.Contains(query)).ToListAsync();

            return View(filteredList);
        }

        // GET: Movie/Details/5
        [HttpGet("/movie/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        //[Route("/movie/create")]
        [HttpGet("/movie/create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/movie/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Genre,Price")] Movie movie)
        {
            if (movie.Title == "Platoon")
            {
                ModelState.AddModelError("FSK18", "FSK Warning: Film zeigt unangbrachten Inhalt");
                ModelState.AddModelError("Title", "Film zeigt unangbrachten Inhalt");
            }


            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Edit/
        [HttpGet("/movie/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/movie/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        [HttpGet("/movie/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost("/movie/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }

        [HttpPost("/movie/buy/{id}")]
        public IActionResult Buy(int? id)
        {


            if (!id.HasValue)
                return BadRequest();

            if (HttpContext.Session.IsAvailable)
            {
                List<int> idList = new List<int>();

                //Gibt es schon einen Warenkorb Objekt für meine Session 
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    //Wenn ja, wurde schon einmal was gekauft und der Session-Eintrag exisitiert

                    string jsonIdList = HttpContext.Session.GetString("ShoppingCart");

                    //befüllte idList mit existierenden Einkäufe
                    idList = JsonSerializer.Deserialize<List<int>>(jsonIdList);
                }

                idList.Add(id.Value);

                string jsonString = JsonSerializer.Serialize(idList);

                HttpContext.Session.SetString("ShoppingCart", jsonString);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
