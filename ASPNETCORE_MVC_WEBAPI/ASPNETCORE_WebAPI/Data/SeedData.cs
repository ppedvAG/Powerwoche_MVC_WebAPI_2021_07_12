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
                context.Movies.Add(new Movie { Title = "ES", Description = "komischer Clown mit alter Schminke", Genre = Genre.Horror, Price = 12.99m });
                context.Movies.Add(new Movie {  Title = "Star Wars", Description = "Vater sucht Sohn", Genre = Genre.Drama, Price = 19.99m });
                context.Movies.Add(new Movie {  Title = "Star Wars 2", Description = "Rückkehr der C# Programmierer", Genre = Genre.Action, Price = 11.99m });

                context.Movies.Add(new Movie { Title = "Harry Potter 1", Description = "Zaubern ist cool", Genre = Genre.Horror, Price = 12.99m });
                context.Movies.Add(new Movie {  Title = "Herr der Ringe", Description = "Urlaub in Mordor", Genre = Genre.Drama, Price = 19.99m });
                context.Movies.Add(new Movie {Title = "Star Wars 3", Description = "Die Flucht der JavaScript Programmierer", Genre = Genre.Action, Price = 11.99m });

                context.Movies.Add(new Movie {  Title = "Verdammt wir leben noch", Description = "Biographie von Falco", Genre = Genre.Horror, Price = 12.99m });
                context.Movies.Add(new Movie {  Title = "ES 2", Description = "Clown sucht Schminke", Genre = Genre.Drama, Price = 19.99m });
                context.Movies.Add(new Movie {  Title = "Simpsons der Film", Description = "Home und Atomkraftwerk", Genre = Genre.Action, Price = 11.99m });

                context.Movies.Add(new Movie {  Title = "Once Up Time in Hollywood", Description = "OscarFilm", Genre = Genre.Horror, Price = 12.99m });
                context.Movies.Add(new Movie {  Title = "BlackmanMask", Description = "Gute Satire", Genre = Genre.Drama, Price = 19.99m });
                context.Movies.Add(new Movie {  Title = "James Bond", Description = "Angentenfilm", Genre = Genre.Action, Price = 11.99m });

                context.Movies.Add(new Movie {  Title = "Biene Maja", Description = "Wass läuft da mit Willy?", Genre = Genre.Horror, Price = 12.99m });
                context.Movies.Add(new Movie {  Title = "Ghost", Description = "IRgendwas mit Geister", Genre = Genre.Drama, Price = 19.99m });
                context.Movies.Add(new Movie {  Title = "Star Wars 4", Description = "Jeddi Ritter ist langweilig", Genre = Genre.Action, Price = 11.99m });

                context.Movies.Add(new Movie {  Title = "ES", Description = "komischer Clown mit alter Schminke", Genre = Genre.Horror, Price = 12.99m });
                context.Movies.Add(new Movie {  Title = "Star Wars", Description = "Vater sucht Sohn", Genre = Genre.Drama, Price = 19.99m });
                context.Movies.Add(new Movie {  Title = "Star Wars 2", Description = "Rückkehr der C# Programmierer", Genre = Genre.Action, Price = 11.99m });
            }

            context.SaveChanges();
        }
    }
}
