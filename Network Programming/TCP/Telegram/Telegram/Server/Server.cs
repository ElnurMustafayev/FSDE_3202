using Server.EntityFramework;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static TelegramDbContext Context = new TelegramDbContext();

        static async Task Main(string[] args)
        {
            List<TcpClient> clients = new List<TcpClient>();

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            const int port = 8080;

            var server = new TcpListener(ip, port);

            server.Start(backlog: 15);
            Console.WriteLine("Server started...");

            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                clients.Add(client);

                Console.WriteLine("User connected...");
                byte[] buffer = new byte[65000];

                //var networkStream = client.GetStream();
                //var size = await networkStream.ReadAsync(buffer);
                //string receivedMessage = Encoding.UTF8.GetString(buffer, 0, size);
                //Console.WriteLine(receivedMessage);

                ThreadPool.QueueUserWorkItem(async (obj) =>
                {
                    while (true)
                    {
                        try
                        {
                            var reader = new StreamReader(client.GetStream());
                            string JSON = await reader.ReadLineAsync();
                            var message = JsonSerializer.Deserialize<Message>(JSON);

                            await Context.Messages.AddAsync(message);
                            await Context.SaveChangesAsync();

                            Console.WriteLine($"{message.SenderName}: '{message.Content}'");
                        }
                        catch (Exception)
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
