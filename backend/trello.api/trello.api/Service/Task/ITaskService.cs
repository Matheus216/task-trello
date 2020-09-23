using trello.api.Models;

namespace trello.api.Service.Task
{
    public interface ITaskService
    {
        TaskModel Save(TaskModel task);    
        TaskModel Remove(int id);    
        TaskModel Get();    
        TaskModel Get(int id);    
        bool IsValid(TaskModel task);
    }
}