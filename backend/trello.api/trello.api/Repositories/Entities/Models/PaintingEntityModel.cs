using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Repositories.Entities.Models
{
    public class PaintingEntityModel : PaintingAbstractModel
    {
        public ICollection<PanelEntityModel> Panel { get; set; }
    }
}