using System.Collections.Generic;
using trello.api.Models;

namespace trello.api.Service.Check
{
    public interface ICheckService
    {
        CheckModel Save(CheckModel param); 
        IList<CheckModel> Get();
        CheckModel Get(int id);
        void Remove(int id); 
    }
}