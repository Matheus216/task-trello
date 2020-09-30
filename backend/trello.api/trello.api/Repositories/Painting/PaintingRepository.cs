using System;
using System.Collections.Generic;
using System.Linq;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.Painting
{
    public class PaintingRepository : IPaintingRepository
    {
        private readonly ContextDB _context;

        public PaintingRepository()
        {
            _context = new ContextDB();
        }

        public void Delete(int id)
        {
            var searchObj = GetById(id);

            _context.Paitings.Remove(searchObj);
            _context.SaveChanges(); 
        }

        public List<PaintingEntityModel> GetAll()
        {
            var _search = _context.Paitings
                .ToList(); 

            if (_search == null) {
                _search = new List<PaintingEntityModel>(); 
            }

            return _search; 
        }

        public PaintingEntityModel GetById(int id)
        {
            var searchObj = _context.Paitings?
                .FirstOrDefault(x => x.PaintingId == id); 

            if (searchObj == null) { 
                searchObj = new PaintingEntityModel(); 
            }

            return searchObj; 
        }

        public PaintingEntityModel Insert(PaintingEntityModel objIn)
        {
            var insered = _context.Paitings.Add(objIn); 
            _context.SaveChanges(); 

            return insered.Entity; 
        }

        public PaintingEntityModel Update(PaintingEntityModel objIn)
        {
            var updated = _context.Paitings.Update(objIn); 

            _context.SaveChanges(); 

            return updated.Entity; 
        }
    }
}