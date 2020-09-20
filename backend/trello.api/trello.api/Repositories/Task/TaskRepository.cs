using System.Collections.Generic;
using System.Linq;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.Task
{
    public class TaskRepository : ITaskRepository
    {
        private ContextDB context; 
        public TaskRepository()
        {
            context = new ContextDB(); 
        }

        public void Delete(int id)
        {
            var searhTask = GetById(id); 

            context.Task.Remove(searhTask); 
            context.SaveChanges(); 
        }

        public List<TaskEntityModel> GetAll()
        {
            var searchTask =  context.Task.ToList(); 

            return searchTask; 
        }

        public TaskEntityModel GetById(int id)
        {
            var searchTask =  context.Task?.FirstOrDefault(x => x.TaskId == id); 

            if (searchTask == null) {
                searchTask =  new TaskEntityModel(); 
            }

            return searchTask;             
        }

        public TaskEntityModel Insert(TaskEntityModel task)
        {
            var insered = context.Task.Add(task);
            
            context.SaveChanges(); 

            return insered.Entity;     
        }

        public TaskEntityModel Update(TaskEntityModel objIn)
        {
            var updateObj = context.Task.Update(objIn);

            context.SaveChanges(); 

            return updateObj.Entity;
        }
    }
}