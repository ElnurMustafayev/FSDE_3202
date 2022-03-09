using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://*:80/");
            server.Start();

            HttpListenerContext context = await server.GetContextAsync();
            var requestReader = new StreamReader(context.Request.InputStream);

            string requestStr = await requestReader.ReadToEndAsync();
            Console.WriteLine(requestStr);
        }
    }
}
