using System.Collections.Generic;
using System.Linq;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.TaskCheck
{
    public class TaskCheckRepository : ITaskCheckRepository
    {
       private ContextDB _context; 
        public TaskCheckRepository()
        {
            _context = new ContextDB(); 
        }

        public void Delete(int id)
        {
            var searchObj = GetById(id);

            _context.TaskCheck.Remove(searchObj);
            _context.SaveChanges(); 
        }

        public List<TaskCheckEntityModel> GetAll()
        {
            var _search = _context.TaskCheck
                .ToList(); 

            return _search; 
        }

        public IList<TaskCheckEntityModel> GetByCheckId(int id)
        {
            var searchObj = _context.TaskCheck?
                .Where(x => x.CheckId == id)
                .ToList(); 

            if (searchObj == null) { 
                searchObj = new List<TaskCheckEntityModel>(); 
            }

            return searchObj; 
        }

        public TaskCheckEntityModel GetById(int id)
        {
            var searchObj = _context.TaskCheck?
                .FirstOrDefault(x => x.TaskId == id); 

            if (searchObj == null) { 
                searchObj = new TaskCheckEntityModel(); 
            }

            return searchObj; 
        }

        public IList<TaskCheckEntityModel> GetByTaskId(int id)
        {
            var searchObj = _context.TaskCheck?
                .Where(x => x.TaskId == id)
                .ToList(); 

            if (searchObj == null) { 
                searchObj = new List<TaskCheckEntityModel>(); 
            }

            return searchObj; 
        }

        public TaskCheckEntityModel Insert(TaskCheckEntityModel objIn)
        {
            var insered = _context.TaskCheck.Add(objIn); 
            _context.SaveChanges(); 

            return insered.Entity; 
        }

        public TaskCheckEntityModel Update(TaskCheckEntityModel objIn)
        {
            var updated = _context.TaskCheck.Update(objIn); 

            _context.SaveChanges(); 

            return updated.Entity; 
        }
    }
}