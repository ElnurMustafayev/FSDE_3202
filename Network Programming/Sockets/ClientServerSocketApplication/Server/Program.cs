using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Socket socket = new Socket(
                addressFamily: AddressFamily.InterNetwork,
                socketType: SocketType.Stream,
                protocolType: ProtocolType.Tcp
                );

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, 8080);

            socket.Bind(endPoint);
            socket.Listen(10);

            while(true)
            {
                var client = await socket.AcceptAsync();
                
                Console.WriteLine($"{client.ProtocolType} " +
                    $"{client.AddressFamily} " +
                    $"{client.SocketType} " +
                    $"{client.LocalEndPoint.ToString()}");
            }
        }
    }
}
