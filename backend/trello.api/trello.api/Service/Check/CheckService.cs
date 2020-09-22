using System.Collections.Generic;
using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Check;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Service.Check
{
    public class CheckService : ICheckService
    {
        public ICheckRepository _repository { get; set; }
        public IMapper _mapper { get; set; }

        public CheckService(ICheckRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public CheckModel Save(CheckModel request)
        {
            var mapperModel =  _mapper.Map<CheckEntityModel>(request); 
            var check = new CheckEntityModel(); 

            if (mapperModel.CheckId == 0) 
            {
                check = _repository.Insert(mapperModel); 
            }
            else
            {
                check = _repository.Update(mapperModel); 
            }

            return _mapper.Map<CheckModel>(check);
        }

        public void Remove(int id) 
        {
            _repository.Delete(id); 
        }

        public IList<CheckModel> Get()
        {
            var searchCheck =  _mapper.Map<List<CheckModel>>(_repository.GetAll());

            return searchCheck; 
        }

        public CheckModel Get(int id) 
        {
            var searchCheck = _mapper.Map<CheckModel>(_repository.GetById(id)); 

            return searchCheck; 
        }
    }
}