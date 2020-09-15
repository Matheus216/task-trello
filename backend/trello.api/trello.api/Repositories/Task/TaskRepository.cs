
using System;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public List<TaskEntityModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TaskEntityModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public TaskEntityModel Insert(TaskEntityModel task)
        {
            var insered = context.Task.Add(task);
            context.SaveChanges(); 

            return insered.Entity;     
        }

        public TaskEntityModel Update(TaskEntityModel objIn)
        {
            throw new System.NotImplementedException();
        }
    }
}