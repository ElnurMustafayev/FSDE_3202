using BaseProject;
using System;
using System.Linq;

namespace EFCorePlugin
{
    public class EfCoreUserService : IUserService
    {
        private readonly DataContext context;

        public EfCoreUserService()
        {
            this.context = new DataContext();
        }

        public EfCoreUserService(DataContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);

            context.SaveChanges();
        }

        public User GetById(int id)
        {
            return (from u in context.Users
                    where u.Id == id
                    select u).FirstOrDefault();
        }
    }
}