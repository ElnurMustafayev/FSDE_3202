using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

            ThreadPool.QueueUserWorkItem(async (obj) =>
            {
                while (true)
                {
                    byte[] buffer = new byte[65000];
                    int size = await socket.ReceiveAsync(buffer, SocketFlags.None);
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, size);
                    Console.WriteLine(receivedMessage);
                }
            });

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
