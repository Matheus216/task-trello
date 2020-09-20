using System.Collections.Generic;
using System.Linq;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.Panel
{
    public class PanelRepository : IPanelRepository
    {
        private ContextDB _context;
        public PanelRepository()
        {
            _context = new ContextDB();
        }

        public void Delete(int id)
        {
            var searchObj = GetById(id);

            _context.Panels.Remove(searchObj);
            _context.SaveChanges();
        }

        public List<PanelEntityModel> GetAll()
        {
            var _search = _context.Panels
                .ToList();

            return _search;
        }

        public PanelEntityModel GetById(int id)
        {
            var searchObj = _context.Panels?
                .FirstOrDefault(x => x.PanelId == id);

            if (searchObj == null) {
                searchObj = new PanelEntityModel(); 
            }

            return searchObj;
        }

        public PanelEntityModel Insert(PanelEntityModel objIn)
        {
            var insered = _context.Panels.Add(objIn);
            _context.SaveChanges();

            return insered.Entity;
        }

        public PanelEntityModel Update(PanelEntityModel objIn)
        {
            var updated = _context.Panels.Update(objIn);

            _context.SaveChanges();

            return updated.Entity;
        }
    }
}