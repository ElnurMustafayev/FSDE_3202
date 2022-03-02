using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // WebClient: low level
            if(false)
            {
                WebClient client = new WebClient();

                Uri urlAddress = new Uri(@"https://itstep.org/en");

                string html = client.DownloadString(urlAddress);

                Console.WriteLine(html);
            }

            if(false)
            {
                string apiString = @"https://pogoapi.net/api/v1/pokemon_names.json";
                HttpWebRequest request = HttpWebRequest.Create(apiString) as HttpWebRequest;

                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;

                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    var json = stream.ReadToEnd();
                    var pokemonResponse = JsonSerializer.Deserialize<PokemonResponse>(json);
                }
            }
        }
    }
}