using System.Collections.Generic;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.TaskCheck
{
    public interface ITaskCheckRepository : IRepository<TaskCheckEntityModel>
    {
        IList<TaskCheckEntityModel> GetByTaskId(int id);
        IList<TaskCheckEntityModel> GetByCheckId(int id); 
    }
}