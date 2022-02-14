using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
            socket.Listen(3);

            while(true)
            {
                var client = await socket.AcceptAsync();
                Console.WriteLine("User connected...");

                ThreadPool.QueueUserWorkItem(async (obj) =>
                {
                    while (true)
                    {
                        try
                        {
                            byte[] buffer = new byte[65000];
                            int size = await client.ReceiveAsync(buffer, SocketFlags.None);

                            var message = Encoding.UTF8.GetString(buffer, 0, size);
                            Console.WriteLine(message);
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("User disconnected...");
                            break;
                        }
                    }
                });
            }
        }
    }
}
