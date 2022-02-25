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
                Task.Run(() => SetImage());
            }
            );

        private void SetImage()
        {
            var imgInBytes = CaptureScreen();
            var server = new UdpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(
                address: IPAddress.Parse("127.0.0.1"),
                port: 8080
                );
            server.Send(imgInBytes, imgInBytes.Length, serverEndPoint);
            return;

            while (true)
            {
                Thread.Sleep(1);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Image = ByteToImage(CaptureScreen());
                });
            }
        }

        public ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;
            return imgSrc;
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
            objBitmap.Save(memory, ImageFormat.Png);
            return memory.GetBuffer();
        }
    }
}
