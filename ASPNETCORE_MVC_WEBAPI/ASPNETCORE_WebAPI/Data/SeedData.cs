using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCORE_WebAPI.Models;

namespace ASPNETCORE_WebAPI.Data
{
    public class SeedData
    {
        public static void Init (MovieDbContext context)
        {
            //Wenn Movie-Tabelle leer ist, dann werden Testdaten hinzugefügt 
            if (!context.Movies.Any())
            {
                context.Movies.Add(new Movie { Id = 1, Title = "ES", Description = "komischer Clown mit alter Schminke", Genre = Genre.Horror, Price = 12.99m });
                context.Movies.Add(new Movie { Id = 2, Title = "Star Wars", Description = "Vater sucht Sohn", Genre = Genre.Drama, Price = 19.99m });
                context.Movies.Add(new Movie { Id = 3, Title = "Star Wars 2", Description = "Rückkehr der C# Programmierer", Genre = Genre.Action, Price = 11.99m });
            }

            context.SaveChanges();
        }
    }
}
