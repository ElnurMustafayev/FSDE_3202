using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SocketsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Socket client;
        private IPEndPoint serverIpEndPoint;
        public MainWindow()
        {
            InitializeComponent();

            this.client = new Socket(
                addressFamily: AddressFamily.InterNetwork,
                socketType: SocketType.Stream,
                protocolType: ProtocolType.Tcp
                );

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            this.serverIpEndPoint = new IPEndPoint(ip, 8080);

            ConnectToServer();
        }

        private async Task ConnectToServer()
        {
            await this.client.ConnectAsync(this.serverIpEndPoint);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message()
            {
                SenderName = this.ClientName?.Text,
                MessageStr = this.ClientMessage?.Text,
            };

            string JSON = JsonSerializer.Serialize(message);

            var messageInBytes = Encoding.UTF8.GetBytes(JSON);
            await this.client.SendAsync(messageInBytes, SocketFlags.None);

            this.ClientMessage.Text = string.Empty;
            this.ClientName.Text = string.Empty;
        }
    }
}
