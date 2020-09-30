using System.Collections.Generic;
using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Panel;

namespace trello.api.Service.Panel
{
    public class PanelService : IPanelService
    {
        private readonly IPanelRepository _repository;
        public IMapper _mapper { get; set; }

        public PanelService(IPanelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public IList<PanelModel> Get()
        {
            var panels = _mapper.Map<List<PanelModel>>(_repository.GetAll()); 

            return panels;
        }

        public IList<PanelModel> GetByPaitingId(int id)
        {
            throw new System.NotImplementedException();
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