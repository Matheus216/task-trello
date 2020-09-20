using System.Collections.Generic;
using System.Linq;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.Check
{
    public class CheckRepository : ICheckRepository
    {
        private ContextDB _context; 
        public CheckRepository()
        {
            _context = new ContextDB(); 
        }

        public void Delete(int id)
        {
            var searchObj = GetById(id);

            _context.Check.Remove(searchObj);
            _context.SaveChanges(); 
        }

        public List<CheckEntityModel> GetAll()
        {
            var _search = _context.Check
                .ToList(); 

            return _search; 
        }

        public CheckEntityModel GetById(int id)
        {
            var searchObj = _context.Check?
                .FirstOrDefault(x => x.CheckId == id); 

            if (searchObj == null) { 
                searchObj = new CheckEntityModel(); 
            }

            return searchObj; 
        }

        public CheckEntityModel Insert(CheckEntityModel objIn)
        {
            var insered = _context.Check.Add(objIn); 
            _context.SaveChanges(); 

            return insered.Entity; 
        }

        public CheckEntityModel Update(CheckEntityModel objIn)
        {
            var updated = _context.Check.Update(objIn); 

            _context.SaveChanges(); 

            return updated.Entity; 
        }
    }
}