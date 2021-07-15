using ASPNETCORE_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Data
{
    public class MovieDbContext :DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
