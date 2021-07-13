using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bitte geben sie einen Filmtitel ein!")]
        public string Title { get; set; }

        [MaxLength(40)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bitte wählen sie ein Genre aus!")]
        public Genre Genre { get; set; }

        [DisplayName("Preis")]
        public decimal Price { get; set; }
    }


    public enum Genre { Action=1, Comedy, Thriller, Drame, Animation, Romance, Crime, Doku}
}
