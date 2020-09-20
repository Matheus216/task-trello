using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Repositories.Entities.Models
{
    public class PanelEntityModel : PanelAbstractModel
    {
        public PaintingEntityModel Painting { get; set; }
        public ICollection<TaskEntityModel> Task { get; set; }
        public ICollection<TaskCheckEntityModel> Check { get; set; }
    }
}