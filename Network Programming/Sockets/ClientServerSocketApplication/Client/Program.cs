using System;
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
            Socket socket = new Socket(
                addressFamily: AddressFamily.InterNetwork,
                socketType: SocketType.Stream,
                protocolType: ProtocolType.Tcp
                );

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, 8080);

            await socket.ConnectAsync(endPoint);

            while(true)
            {
                Console.Write("Message: ");
                string message = Console.ReadLine();
                var messageInBytes = Encoding.UTF8.GetBytes(message);

                await socket.SendAsync(messageInBytes, SocketFlags.None);
            }
        }
    }
}
