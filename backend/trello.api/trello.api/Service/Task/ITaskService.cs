using System.Collections.Generic;
using trello.api.Models;

namespace trello.api.Service.Task
{
    public interface ITaskService
    {
        TaskModel Save(TaskModel task);    
        void Remove(int id);    
        IList<TaskModel> Get();    
        TaskModel Get(int id);    
        List<TaskModel> GetByPanelId(int id);    
    }
}