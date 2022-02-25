using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new UdpClient(8080);
            Console.WriteLine("Server started...");

            IPEndPoint clientEndPoint = null;

            for (int i = 0; true; i++)
            {
                byte[] data = server.Receive(ref clientEndPoint);

                Console.WriteLine($"{i}.\tClient IP: {clientEndPoint.Address}");
                Console.WriteLine($"Message: {Encoding.UTF8.GetString(data)}");
            }
        }
    }
}
