using System.Collections.Generic;
using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Panel;
using trello.api.Repositories.Task;

namespace trello.api.Service.Panel
{
    public class PanelService : IPanelService
    {
        private readonly IPanelRepository _repository;
        private readonly ITaskRepository _taskRepository;
        public IMapper _mapper { get; set; }

        public PanelService(IPanelRepository repository, IMapper mapper, ITaskRepository taskRepository)
        {
            _repository = repository;
            _mapper = mapper; 
            _taskRepository = taskRepository; 
        }

        public IList<PanelModel> Get()
        {
            var panels = _mapper.Map<List<PanelModel>>(_repository.GetAll()); 

            foreach (var x in panels)
            {
                x.Task =  _mapper.Map<List<TaskModel>>(_taskRepository.GetByPanelId(x.PanelId));
            }

            return panels;
        }

        public IList<PanelModel> GetByPaitingId(int id)
        {
            var search = _mapper.Map<List<PanelModel>>(_repository.GetByPaitingId(id)); 

            foreach (var x in search)
            {
                x.Task =  _mapper.Map<List<TaskModel>>(_taskRepository.GetByPanelId(x.PanelId));
            }

            return search; 
        }

        public PanelModel Save(PanelModel panel)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}