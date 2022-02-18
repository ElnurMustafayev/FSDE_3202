using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new TcpClient();

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            await client.ConnectAsync(ip, 8080);

            var networkStream = client.GetStream();
            var reader = new StreamReader(networkStream);
            var writer = new StreamWriter(networkStream);

            //Console.Write("Message: ");
            //string message = Console.ReadLine();
            //byte[] messageInBytes = Encoding.UTF8.GetBytes(message);
            //await networkStream.WriteAsync(messageInBytes);

            while(true)
            {
                Console.Write("Message: ");
                await writer.WriteLineAsync(Console.ReadLine());
                await writer.FlushAsync();
            }
        }
    }
}
