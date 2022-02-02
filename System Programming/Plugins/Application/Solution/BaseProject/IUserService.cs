using System;

namespace BaseProject
{
    // CRUD operations
    public interface IUserService
    {
        void Add(User user);
        User GetById(int id);
    }
}
