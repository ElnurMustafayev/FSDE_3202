using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] message = Encoding.UTF8.GetBytes("Hello World!");

            var client = new UdpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(
                address: IPAddress.Parse("127.0.0.1"),
                port: 8080
                );

            for (int i = 0; i < 100; i++)
            {
                client.Send(
                    dgram: message,
                    bytes: message.Length,
                    endPoint: serverEndPoint
                    );
            }
        }
    }
}
