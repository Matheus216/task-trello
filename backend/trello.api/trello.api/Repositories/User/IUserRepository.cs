using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.User
{
    public interface IUserRepository : IRepository<UserEntityModel>
    {
         /* caso tenha uma regra especifica para esse contexto */
    }
}