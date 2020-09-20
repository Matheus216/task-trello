using trello.api.Models;

namespace trello.api.Service.Check
{
    public interface ICheckService
    {
        CheckModel Save(CheckModel param); 
    }
}