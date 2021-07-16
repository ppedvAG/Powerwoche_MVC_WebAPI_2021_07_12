using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;

namespace LinqAndLamdaSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {

                new Person {Id=1, Age=37, Vorname="Kevin", Nachname="Winter"},
                new Person {Id=2, Age=29, Vorname="Hannes", Nachname="Preishuber"},
                new Person {Id=3, Age=19, Vorname="Scott", Nachname="Hunter"},
                
                new Person {Id=4, Age=21, Vorname="Scott", Nachname="Hanselmann"},
                new Person {Id=5, Age=45, Vorname="Daniel", Nachname="Roth"},
                new Person {Id=6, Age=50, Vorname="Bill", Nachname="Gates"},
                
                new Person {Id=7, Age=70, Vorname="Newton", Nachname="King"},
                new Person {Id=8, Age=40, Vorname="Andre", Nachname="R"},
                new Person {Id=9, Age=60, Vorname="Petra", Nachname="Musterfrau"},
            };

            //Linq Statement -> using System.Linq;

            IList<Person> lingStatementResult = (from p in persons
                                                 where p.Age >= 40 && p.Age < 50
                                                 orderby p.Nachname
                                                 select p).ToList();



            //Linq-Funktionen (Where/Orderby/ThenBy)
            //Lambda Expression:  p => p.Age >= 40 && p.Age < 50
            IList<Person> reult = persons
                .Where(p => p.Age >= 40 && p.Age < 50)
                .OrderBy(o => o.Nachname)
                .ThenBy(a => a.Age)
                .ToList();


            double altersdurchschnitt = persons.Where(p => p.Age > 30).Average(a => a.Age);
            Person selectedPerson = persons.Single(s => s.Id == 4);
            Person ersteElementInDerList = persons.FirstOrDefault();
            Person letzteElementInListe = persons.Last();
            double gesamtAlter = persons.Sum(s => s.Age);


            //Pagging -> Skip / Take
            int pagingNumber = 1;
            int pagingSize = 3; //Wieviele Elemente werden auf einer Seite angezeigt


            IList<Person> ergebnisSeite1 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();
            
            pagingNumber = 2;
            IList<Person> ergebnisSeite2 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

            pagingNumber = 3;
            IList<Person> ergebnisSeite3 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();


            if (ergebnisSeite1.Count == 0)
            {
                //Liste ist leer
            }

            if (!ergebnisSeite1.Any())
            {
                //Liste ist leer
            }


            

        }
    }

    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
