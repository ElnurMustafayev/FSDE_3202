using BaseProject;
using GalaSoft.MvvmLight;
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
        public ObservableCollection<User> Users { get; set; }

        public List<IUserService> userServicesCollection = new List<IUserService>();

        public MainViewModel()
        {
            var dllFiles = Directory.GetFiles(path: "Plugins")
                .Where(filename => filename.EndsWith(".dll"));

            foreach (var file in dllFiles)
            {
                string absolutePath = $@"{Directory.GetCurrentDirectory()}\{file}";
                var pluginAssembly = Assembly.LoadFile(absolutePath);
                var userServices = from t in pluginAssembly.GetTypes()
                                   where t.GetInterface("IUserService") != null
                                   select t;

                var services = userServices.Select(t =>
                {
                    return Activator.CreateInstance(t) as IUserService;
                });
                userServicesCollection.AddRange(services);
            }

            IUserService userService = new UserLocalService();
            this.Users = new ObservableCollection<User>();

            UserLocalService.Users = this.Users;
            userService.Add(new User("Ergun", "Taqiyev", 16));
            userService.Add(new User("Imran", "Jabrayilov", 20));
        }
    }
}
