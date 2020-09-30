using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Painting;
using trello.api.Service.Panel;

namespace trello.api.Service.Painting
{
    public class PaintingService : IPaintingService
    {
        private readonly IPaintingRepository _repository; 
        private readonly IPanelService _servicePanel; 
        private readonly IMapper _mapper;

        public PaintingService(IPaintingRepository repository, IMapper mapper, IPanelService servicePanel)
        {
            _repository = repository; 
            _mapper = mapper;
            _servicePanel = servicePanel; 
        }

        public PaintingModel GetPainting() 
        {
            var search = _mapper.Map<PaintingModel>(_repository.GetById(1)); 
            search.Panel = _servicePanel.GetByPaitingId(search.PaintingId); 

            return search; 
        }
    }
} 