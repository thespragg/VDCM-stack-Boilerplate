using server.Models;
using System.Collections.Generic;

namespace server.Services.Interfaces
{
    public interface IUserService
    {
        User Create(User user);
        User FindByEmail(string email);
        User FindByUsername(string username);
        List<User> Get();
        User Get(string id);
        void Remove(string id);
        void Remove(User userIn);
        void Update(string id, User userIn);
    }
}