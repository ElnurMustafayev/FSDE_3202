using ShopApplication.Services;
using ShopApplication.Tools;
using ShopApplication.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShopApplication
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
            SetStartWindow<SecondViewModel>();
        }

        private void SetServices()
        {
            Container = new Container();

            Container.RegisterSingleton<IProductService, ProductEfCoreService>();

            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<SecondViewModel>();
            Container.RegisterSingleton<MainViewModel>();

            Container.Verify();
        }

        private void SetStartWindow<T>() where T: ViewModelBase
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.ActiveViewModel = Activator.CreateInstance<T>();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainViewModel;

            mainWindow.ShowDialog();
        }
    }
}
