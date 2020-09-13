using System;
using System.Collections.Generic;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.Paiting
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
            throw new NotImplementedException();
        }
 
        public List<PaintingEntityModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PaintingEntityModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PaintingEntityModel Insert(PaintingEntityModel objIn)
        {
            throw new NotImplementedException();
        }

        public PaintingEntityModel Update(PaintingEntityModel objIn)
        {
            throw new NotImplementedException();
        }
    }
}