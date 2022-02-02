using BaseProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UsersApplication.Services
{
    public class UserLocalService : IUserService
    {
        static int IdCounter;
        public static ObservableCollection<User> Users;

        static UserLocalService()
        {
            IdCounter = 0;
            Users = new ObservableCollection<User>();
        }

        public void Add(User user)
        {
            IdCounter++;
            user.Id = IdCounter;
            Users.Add(user);
            MessageBox.Show($"User {user.FirstName} added!");
        }

        public User GetById(int id)
        {
            var result = from u in Users
                         where u.Id == id
                         select u;

            return result.FirstOrDefault();
        }
    }
}
