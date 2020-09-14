using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Paiting;

namespace trello.api.Service.PaintingService
{
    public class PaintingService : IPaintingService
    {
        private readonly IPaintingRepository _repository; 
        private readonly IMapper _mapper;

        public PaintingService(IPaintingRepository repository, IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        }

        public PaintingModel GetPainting() 
        {
            var search = _mapper.Map<PaintingModel>(_repository.GetAll()); 

            return search; 
        }
    }
} 