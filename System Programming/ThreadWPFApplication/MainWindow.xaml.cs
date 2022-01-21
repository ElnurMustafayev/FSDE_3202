using System;
using System.Collections.Generic;
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

namespace ThreadWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // doesn't work
            //new Thread((obj) =>
            //{
            //    if(obj is ProgressBar MyProgressBar)
            //        MyProgressBar.Value = 80;
            //}).Start(this.MyProgressBar);

            
            // works
            new Thread(() =>
            {
                Console.WriteLine("Start");
                Dispatcher.Invoke(() =>
                {
                    this.MyProgressBar.Value = 80;
                });
                Console.WriteLine("End");
            }).Start();
        }
    }
}
