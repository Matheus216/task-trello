using System.Collections.Generic;
using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Entities.Models;
using trello.api.Repositories.Panel;
using trello.api.Service.Task;

namespace trello.api.Service.Panel
{
    public class PanelService : IPanelService
    {
        private readonly IPanelRepository _repository;
        private readonly ITaskService _taskService;
        public IMapper _mapper { get; set; }

        public PanelService(IPanelRepository repository, IMapper mapper, ITaskService taskService)
        {
            _repository = repository;
            _mapper = mapper; 
            _taskService = taskService; 
        }

        public IList<PanelModel> Get()
        {
            var panels = _mapper.Map<List<PanelModel>>(_repository.GetAll()); 

            foreach (var x in panels)
            {
                x.Task =  _taskService.GetByPanelId(x.PanelId); 
            }

            return panels;
        }

        public IList<PanelModel> GetByPaitingId(int id)
        {
            var search = _mapper.Map<List<PanelModel>>(_repository.GetByPaitingId(id)); 

            foreach (var x in search)
            {
                x.Task =  _taskService.GetByPanelId(x.PanelId); 
            }

            return search; 
        }

        public PanelModel Save(PanelModel panel)
        {
            var entityPanel = _mapper.Map<PanelEntityModel>(panel); 
            var panelInsered = _mapper.Map<PanelModel>(_repository.Insert(entityPanel));

            return panelInsered;
        }

        public PanelModel UpdateDescription(int id, string description)
        {
            var search = _mapper.Map<PanelModel>(_repository.GetById(id));

            search.Title = description; 

            var updated = _repository.Update
            (
                _mapper.Map<PanelEntityModel>(search)
            ); 

            return _mapper.Map<PanelModel>(updated); 
        }
        public void Remove(int id)
        {
            _repository.Delete(id); 
        }
    }
}