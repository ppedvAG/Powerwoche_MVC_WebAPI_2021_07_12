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
