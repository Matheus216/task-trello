using trello.api.Models;
using trello.api.Repositories.Check;

namespace trello.api.Service.Check
{
    public class CheckService : ICheckService
    {
        public ICheckRepository _repository { get; set; }

        public CheckService(ICheckRepository repository)
        {
            _repository = repository;
        }

        public CheckModel Save(CheckModel request)
        {
            throw new System.NotImplementedException();
        }
    }
}