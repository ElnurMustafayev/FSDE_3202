using Client.Services;
using Client.Tools;
using Client.ViewModels;
using GalaSoft.MvvmLight;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetServices();
            SetStartWindow<RegistrationViewModel>();
        }

        private void SetServices()
        {
            Container = new Container();

            Container.RegisterSingleton<IMessenger, Messenger>();

            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<RegistrationViewModel>();

            Container.Verify();
        }

        private void SetStartWindow<T>() where T : ViewModelBase
        {
            var mainViewModel = Container.GetInstance<MainViewModel>();
            mainViewModel.ActiveViewModel = Container.GetInstance<T>();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainViewModel;

            mainWindow.ShowDialog();
        }
    }
}
