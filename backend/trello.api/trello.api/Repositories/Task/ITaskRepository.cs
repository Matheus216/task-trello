using System.Collections.Generic;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.Task
{
    public interface ITaskRepository : IRepository<TaskEntityModel>
    {
        IList<TaskEntityModel> GetByPanelId(int id ); 
    }
}