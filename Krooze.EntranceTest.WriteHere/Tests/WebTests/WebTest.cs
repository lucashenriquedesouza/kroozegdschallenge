using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Linq;

namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public class WebTest
    {

        private const string urlAPI = "https://swapi.co/api/";

        public JObject GetAllMovies()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the films object

            string method = "films";

            return (JObject)JsonConvert.DeserializeObject(new HttpClient().GetStringAsync($"{urlAPI}{method}/").Result);
        }

        public string GetDirector()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the name of person that directed the most star wars movies, based on the films object return

            string method = "films";

            return ((JObject)JsonConvert.DeserializeObject(new HttpClient().GetStringAsync($"{urlAPI}{method}/").Result))["results"].Value<JArray>()
                    .GroupBy(director => director["director"])
                    .Select(group => new { director = group.Key, movies = group.Count() })
                    .OrderByDescending(director => director.movies)
                    .FirstOrDefault()
                    .director
                    .ToString();

        }

    }
}
