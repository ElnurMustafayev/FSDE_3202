using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Server.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private UdpClient Server;


        private ImageSource image;

        public ImageSource Image
        {
            get { return image; }
            set { base.Set(ref image, value); }
        }


        public MainViewModel()
        {
            Task.Run(async () =>
            {
                this.Server = new UdpClient(8080);

                IPEndPoint clientEndPoint = null;

                int counter = 0;

                using (MemoryStream memory = new MemoryStream())
                {
                    while (true)
                    {
                        memory.SetLength(0);
                        while (true)
                        {
                            byte[] responseInBytes = Server.Receive(ref clientEndPoint);

                            if(responseInBytes.Length < 100)
                            {
                                string responseStr = Encoding.UTF8.GetString(responseInBytes);

                                if (responseStr == "END IMAGE")
                                {
                                    break;
                                }
                            }

                            memory.Write(responseInBytes, 0, responseInBytes.Length);
                        }

                        byte[] imageInBytes = memory.GetBuffer();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Image = ByteToImage(imageInBytes);
                        });
                    }
                }
            });
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
    }
}
