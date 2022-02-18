using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

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

            IEnumerable<string> keywords = (await File.ReadAllLinesAsync("Keywords.txt"))
                .Where(str => string.IsNullOrWhiteSpace(str) == false)
                .Select(str => str.Trim().ToLower());

            while(true)
            {
                Socket client = await socket.AcceptAsync();
                Console.WriteLine("User connected...");

                ThreadPool.QueueUserWorkItem(async (obj) =>
                {
                    while (true)
                    {
                        try
                        {
                            byte[] buffer = new byte[65000];
                            int size = await client.ReceiveAsync(buffer, SocketFlags.None);
                            string message = Encoding.UTF8.GetString(buffer, 0, size);
                            var messageObj = JsonSerializer.Deserialize<Message>(message);

                            Console.WriteLine($"{messageObj.SenderName} says: '{messageObj.MessageStr}'");
                            if (keywords.Contains(message.ToLower().Trim()))
                            {
                                await SendMessageToClient(client, $"{message} is a keyword");
                            } 
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

        static async Task SendMessageToClient(Socket client, string message)
        {
            var messageInBytes = Encoding.UTF8.GetBytes(message);

            await client.SendAsync(messageInBytes, SocketFlags.None);
        }
    }
}
