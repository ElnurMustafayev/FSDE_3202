using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            const int port = 8080;

            var server = new TcpListener(ip, port);

            server.Start(backlog: 15);
            Console.WriteLine("Server started...");

            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                Console.WriteLine("User connected...");
                byte[] buffer = new byte[65000];

                //var networkStream = client.GetStream();
                //var size = await networkStream.ReadAsync(buffer);
                //string receivedMessage = Encoding.UTF8.GetString(buffer, 0, size);
                //Console.WriteLine(receivedMessage);

                try
                {
                    var reader = new StreamReader(client.GetStream());
                    string text = await reader.ReadLineAsync();
                    Console.WriteLine(text);
                }
                catch (Exception)
                {
                    Console.WriteLine("User disconnected...");
                }
            }
        }
    }
}
