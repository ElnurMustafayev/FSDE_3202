using System.Net;
using System.Text;
using System.Text.Json;

namespace Client;

public class User {
    public string Name { get; set; }
}

public class Program {
    public static async Task Main() {
        const string serverUrl = @"https://www.google.az/search?q=pokemonopen+api&bih=961&biw=1920&hl=ru&ei=RkwiYveYJNyHwPAP7-SW0AI&ved=0ahUKEwj304DD_az2AhXcAxAIHW-yBSoQ4dUDCA4&uact=5&oq=pokemonopen+api&gs_lcp=Cgdnd3Mtd2l6EAMyCAgAEAcQHhATMggIABAHEB4QEzoHCAAQRxCwA0oECEEYAEoECEYYAFD1D1i7EGDgEWgFcAF4AIABZIgBxgGSAQMxLjGYAQCgAQHIAQjAAQE&sclient=gws-wiz";

        if(false) {
            var client = new WebClient();

            var uri = new Uri(serverUrl);

            var responseTxt = client.DownloadString(uri);
            Console.WriteLine(responseTxt);
        }

        // GET
        if(false) {
            HttpWebRequest request = WebRequest.CreateHttp(serverUrl);

            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;

            using StreamReader responseReader = new StreamReader(response.GetResponseStream());

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Response: '{await responseReader.ReadToEndAsync()}'");
        }

        // POST
        if(false) {
            HttpWebRequest request = WebRequest.CreateHttp(serverUrl);

            request.Method = HttpMethod.Post.Method;
            request.ContentType = "application/json";

            using(var requestWriter = new StreamWriter(await request.GetRequestStreamAsync())) {

                var login = new {
                    Login = "Elnur",
                    Password = "Secret12345",
                };

                string JSON = JsonSerializer.Serialize(login, login.GetType());

                await requestWriter.WriteAsync(JSON);
                await requestWriter.FlushAsync();
            }

            // send request
            // get response
            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;

            using StreamReader responseReader = new StreamReader(response.GetResponseStream());

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Response: '{await responseReader.ReadToEndAsync()}'");
        }
    
        // PUT
        if(true) {
            HttpClient client = new HttpClient();

            User changedFakeUser = new User();
            changedFakeUser.Name = "Alex";

            var login = new {
                Id = 123,
                User = changedFakeUser,
            };
            string JSON = JsonSerializer.Serialize(login, login.GetType());

            HttpContent content = new StringContent(JSON);

            var response = await client.PutAsync(serverUrl, content);

            var responseStr = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Response: {responseStr}");
        }
    }
}