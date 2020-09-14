using trello.api.Models;

namespace trello.api.Service.Task
{
    public interface ITaskService
    {
        TaskModel Insert(TaskModel task);    
        bool IsValid(TaskModel task);
    }
}