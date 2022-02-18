using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CopyFileApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string fileName = "Copied.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CopyFile(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.FilePathTextBox.Text))
                return;

            this.ProgressBar.Value = 0;

            var path = this.FilePathTextBox.Text;

            var fileStream = new FileStream(path, FileMode.OpenOrCreate);

            int bufferSize = 100;

            double progressbarStepSize = 100d / (fileStream.Length / bufferSize);

            byte[] buffer = new byte[bufferSize];

            int size = -1;
            while (size != 0)
            {
                size = await fileStream.ReadAsync(buffer);

                var text = Encoding.UTF8.GetString(buffer, 0, size);

                Dispatcher.Invoke(() =>
                {
                    this.ProgressBar.Value += progressbarStepSize;
                });
            }

            MessageBox.Show(this.ProgressBar.Value.ToString());
        }
    }
}
