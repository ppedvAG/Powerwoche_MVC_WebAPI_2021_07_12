using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public Person(string Name, int Age, string email)
        {
            this.Name = Name;
            this.Age = Age;
            this.Email = email;
        }
    }
}
