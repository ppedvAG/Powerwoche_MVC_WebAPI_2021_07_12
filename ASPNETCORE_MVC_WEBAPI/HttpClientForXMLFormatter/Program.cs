using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientForXMLFormatter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "https://localhost:5001/api/FormatterSample/";


            #region SendAsync

            string extendedURL = baseUrl + "GetAllMovies";
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));


            HttpResponseMessage response = await client.SendAsync(request);
            
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine("Weiter zu Beispiel2 mit [KeyPress]");
            Console.ReadKey();
            #endregion


            #region Get-Befehl vion HttpClient
            extendedURL = baseUrl + "GetAllMovies";
            HttpResponseMessage response1 = await client.GetAsync(baseUrl);
            Console.WriteLine(response1.Content.ReadAsStringAsync().Result);

            Console.WriteLine("Weiter zu Beispiel3 mit [KeyPress]");
            Console.ReadKey();
            #endregion

            #region Get by Id
            //https://localhost:5001/api/FormatterSample/GetMoviesById/1

            extendedURL = baseUrl + "GetMoviesById/1"; //Die 1 ist die gesuchte ID und kann man via Input auch manuell angeben
            HttpResponseMessage response11 = await client.GetAsync(extendedURL);
            Console.WriteLine(response11.Content.ReadAsStringAsync().Result);
            #endregion


            #region POST Befehl 
            Movie movie = new Movie();
            movie.Title = "Suicide Squad";
            movie.Description = "Actionfilm des Jahres";
            movie.Genre = Genre.Action;
            movie.Price = 29.99m;

            //Serialisieren das Object in ein JSON String
            string jsonString = JsonConvert.SerializeObject(movie);

            //Json String wird im BODY des HTTP-Package gesetzt
            //Zusätzlich wurde angegeben, dass der Body Inhalt ein application/json format besitzt und Encoding UTF8 ist.
            StringContent data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response2 = await client.PostAsync(baseUrl, data);
            string resultCode = await response.Content.ReadAsStringAsync(); //HTTP-Code

            #endregion



            #region PUT 

            string url = baseUrl + 1.ToString();

            string json = JsonConvert.SerializeObject(movie);
            var data1 = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client1 = new HttpClient())
            {
                var response4 = client.PutAsync(url, data1); //Update
                string result = await response.Content.ReadAsStringAsync();
            }
            #endregion

            #region Delete
            url = baseUrl + 1.ToString();
            
            using (HttpClient client2 = new HttpClient())
            {
                HttpResponseMessage response5 = await client.DeleteAsync(url);
                string result = await response5.Content.ReadAsStringAsync();
            }
            #endregion

        }
    }


    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Genre Genre { get; set; }

        public decimal Price { get; set; }
    }

    public enum Genre { Action = 1, Thriller, Comedy, Horror, Animations, Drama, Romance, Documentation }

}
