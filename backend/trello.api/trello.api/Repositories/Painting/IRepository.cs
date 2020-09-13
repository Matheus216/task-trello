using System.Collections.Generic;

namespace trello.api.Repositories.Painting
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Insert(T objIn); 
        T Update(T objIn); 
        void Delete(int id);
    }
}