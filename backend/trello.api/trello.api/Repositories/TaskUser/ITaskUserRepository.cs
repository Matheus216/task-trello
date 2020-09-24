using System.Collections.Generic;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.TaskUser
{
    public interface ITaskUserRepository : IRepository<TaskUserEntityModel>
    {
        TaskUserEntityModel GetById(int taskId, int userId);
        IList<TaskUserEntityModel> GetByTaskId(int taskId);
        IList<TaskUserEntityModel> GetByUserId(int userId);
    }
}