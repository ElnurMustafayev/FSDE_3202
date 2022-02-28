using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Client.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string ip;

        public string IP
        {
            get { return ip; }
            set { Set(ref ip, value); }
        }

        private int port;

        public int Port
        {
            get { return port; }
            set { Set(ref port, value); }
        }

        private ImageSource image;

        public ImageSource Image
        {
            get { return image; }
            set { Set(ref image, value); }
        }

        private RelayCommand shareScreenCommand;

        public RelayCommand ShareScreenCommand => shareScreenCommand ??= new RelayCommand(
            execute: () =>
            {
                Task.Run(() => SendImage());
            }
            );

        private async void SendImage()
        {
            const int packetSize = 5000;

            try
            {
                var server = new UdpClient();
                IPEndPoint serverEndPoint = new IPEndPoint(
                    address: IPAddress.Parse("127.0.0.1"),
                    port: 8080
                    );

                byte[] buffer = new byte[packetSize];
                while(true)
                {
                    Thread.Sleep(1);
                    byte[] imgInBytes = CaptureScreen();
                    using (MemoryStream memory = new MemoryStream(imgInBytes))
                    {
                        while(true)
                        {
                            int size = await memory.ReadAsync(buffer, 0, packetSize);

                            await server.SendAsync(buffer, size, serverEndPoint);

                            if (size == 0)
                                break;
                        }

                        byte[] endMessage = Encoding.UTF8.GetBytes("END IMAGE");
                        await server.SendAsync(endMessage, endMessage.Length, serverEndPoint);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public byte[] CaptureScreen()
        {
            var width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            var height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            using var memory = new MemoryStream();
            Bitmap bmp = new Bitmap(width, height);
            using Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size);
            Bitmap objBitmap = new Bitmap(bmp, (int)(width), (int)(height));
            objBitmap.Save(memory, ImageFormat.Jpeg);
            return memory.GetBuffer();
        }
    }
}
