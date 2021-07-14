using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNETCOREMVC.Models;

namespace ASPNETCOREMVC.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<ASPNETCOREMVC.Models.Movie> Movie { get; set; }

        private void IchWillWasProgrammieren()
        {
            //DBSet beherrscht die selbe Funktionalität wie DBSet-Methoden
            Movie.Add(new Models.Movie());
            Movie.Remove(new Models.Movie());

            IList<Movie> alleFilme = Movie.ToList();
            IList<Movie> alleFilmeWithConditions =  Movie.Where(n => n.Genre == Genre.Action).ToList();
        }

        #region Required
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Movie>()
        //        .Property(b => b.Title)
        //        .IsRequired();
        //}
        #endregion
    }
}
