using trello.api.Models;
using trello.api.Repositories.Paiting;

namespace trello.api.Service.PaintingService
{
    public class PaintingService : IPaintingService
    {
        private readonly IPaintingRepository _repository; 

        public PaintingService(IPaintingRepository repository)
        {
            _repository = repository; 
        }

        public PaintingModel GetPainting() 
        {
            var search = _repository.GetAll(); 


            var painting = new PaintingModel
            {
                Description = search[0].Description,
                PaintingId = search[0].PaintingId,
                Panel = null
            };

            return painting; 
        }
    }
} 