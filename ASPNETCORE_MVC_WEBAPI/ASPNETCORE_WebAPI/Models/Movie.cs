using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Genre Genre { get; set; }

        public decimal Price { get; set; }
    }

    public enum Genre { Action=1, Thriller, Comedy, Horror, Animations, Drama, Romance, Documentation}
}
