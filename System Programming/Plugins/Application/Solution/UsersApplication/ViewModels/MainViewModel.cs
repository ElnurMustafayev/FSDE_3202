using BaseProject;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UsersApplication.Services;

namespace UsersApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public User UserToAdd = new User()
        {
            Id = 0,
            FirstName = "Alex",
            LastName = "Brown",
            Age = 56
        };

        public ObservableCollection<User> Users { get; set; }

        public IUserService CurrentService { get; set; } = new UserLocalService();

        public ObservableCollection<IUserService> UserServicesCollection { get; set; } = new ObservableCollection<IUserService>();

        public MainViewModel()
        {
            UserServicesCollection.Add(CurrentService);

            var dllFiles = Directory.GetFiles(path: "Plugins")
                .Where(filename => filename.EndsWith(".dll"));

            foreach (var file in dllFiles)
            {
                string absolutePath = $@"{Directory.GetCurrentDirectory()}\{file}";
                Assembly pluginAssembly = Assembly.LoadFile(absolutePath);
                var userServices = from t in pluginAssembly.GetTypes()
                                   where t.GetInterface("IUserService") != null
                                   select t;

                var services = userServices.Select(t =>
                {
                    return Activator.CreateInstance(t) as IUserService;
                });

                foreach (var service in services)
                {
                    UserServicesCollection.Add(service);
                }
            }

            this.Users = new ObservableCollection<User>();

            UserLocalService.Users = this.Users;
            CurrentService.Add(new User("Ergun", "Taqiyev", 16));
            CurrentService.Add(new User("Imran", "Jabrayilov", 20));
        }

        private RelayCommand addUserCommand;
        public RelayCommand AddUserCommand
        {
            get => addUserCommand ??= new RelayCommand(() =>
            {
                CurrentService?.Add(UserToAdd);
            });
        }
    }
}
