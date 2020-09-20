using System.Collections.Generic;
using System.Linq;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private ContextDB _context; 
        public UserRepository()
        {
            _context = new ContextDB(); 
        }

        public void Delete(int id)
        {
            var searchObj = GetById(id);

            _context.User.Remove(searchObj);
            _context.SaveChanges(); 
        }

        public List<UserEntityModel> GetAll()
        {
            var _search = _context.User
                .ToList(); 

            return _search; 
        }

        public UserEntityModel GetById(int id)
        {
            var searchObj = _context.User?
                .FirstOrDefault(x => x.UserId == id); 

            if (searchObj == null) { 
                searchObj = new UserEntityModel(); 
            }

            return searchObj; 
        }

        public UserEntityModel Insert(UserEntityModel objIn)
        {
            var insered = _context.User.Add(objIn); 
            _context.SaveChanges(); 

            return insered.Entity; 
        }

        public UserEntityModel Update(UserEntityModel objIn)
        {
            var updated = _context.User.Update(objIn); 

            _context.SaveChanges(); 

            return updated.Entity; 
        }
    }
}