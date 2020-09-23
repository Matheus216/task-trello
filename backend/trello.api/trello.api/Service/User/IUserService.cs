using System.Collections.Generic;
using trello.api.Models;

namespace trello.api.Service.User
{
    public interface IUserService
    {
        UserModel Save(UserModel user);
        void Remove(int id);
        UserModel Get(int id);
        IList<UserModel> Get(); 
    }
}