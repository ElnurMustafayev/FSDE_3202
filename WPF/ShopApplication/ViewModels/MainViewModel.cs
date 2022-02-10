using GalaSoft.MvvmLight.CommandWpf;
using ShopApplication.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ShopApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase activeViewModel;
        public ViewModelBase ActiveViewModel
        {
            get { return activeViewModel; }
            set { PropertyChangeMethod(ref activeViewModel, value); }
        }

        private string text = "Done!";
        public string Text
        {
            get => text;
            set
            {
                PropertyChangeMethod(ref text, value);
            }
        }

        private int number = 123;
        public int Number
        {
            get => number;
            set
            {
                PropertyChangeMethod(ref number, value);
            }
        }

        CommandBase clickCommand;
        public CommandBase ClickCommand => clickCommand ??= new CommandBase()
        {
            execute = () =>
            {
                Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    this.ActiveViewModel = new HomeViewModel();
                    this.Text = Guid.NewGuid().ToString();
                    commandFlag = false;
                });
            },
            canExecute = () => commandFlag,
        };
        private bool commandFlag = true;

        public MainViewModel() 
        {
            //Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    Text = "Finish!";
            //    Number = 111111111;
            //});

            //RelayCommand command = new RelayCommand()
        }
    }
}
