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
            var search = _repository.Get(); 

            var painting = new PaintingModel
            {
                Description = search.Description,
                PaintingId = search.PaintingId,
                Panel = search.Panel
            };

            return painting; 
        }
    }
}