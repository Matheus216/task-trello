using System.Collections.Generic;
using System.Linq;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.TaskUser
{
    public class TaskUserRepository : ITaskUserRepository
    {
        private ContextDB _context;
        public TaskUserRepository()
        {
            _context = new ContextDB();
        }

        public void Delete(int id)
        {
            var searchObj = GetById(id);

            _context.TaskUser.Remove(searchObj);
            _context.SaveChanges();
        }

        public List<TaskUserEntityModel> GetAll()
        {
            var _search = _context.TaskUser
                .ToList();

            if (_search == null)
            {
                _search = new List<TaskUserEntityModel>();
            }

            return _search;
        }
        public TaskUserEntityModel Insert(TaskUserEntityModel objIn)
        {
            var insered = _context.TaskUser.Add(objIn);
            _context.SaveChanges();

            return insered.Entity;
        }

        public TaskUserEntityModel Update(TaskUserEntityModel objIn)
        {
            var updated = _context.TaskUser.Update(objIn);

            _context.SaveChanges();

            return updated.Entity;
        }
        public TaskUserEntityModel GetById(int taskId, int userId)
        {
            var searh = _context.TaskUser?.FirstOrDefault(x => x.TaskId == taskId && x.UserId == userId); 

            return searh; 
        }
        
        public TaskUserEntityModel GetById(int taskId)
        {
            throw new System.NotImplementedException();
        }

        public IList<TaskUserEntityModel> GetByTaskId(int taskId)
        {
            var _search = _context.TaskUser?
                .Where(x => x.TaskId == taskId)
                .ToList(); 

            return _search; 
        }

        public IList<TaskUserEntityModel> GetByUserId(int userId)
        {
            var _search = _context.TaskUser?
                .Where(x => x.UserId == userId)
                .ToList(); 

            return _search; 
        }
    }
}