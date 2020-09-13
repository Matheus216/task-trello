using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Models
{
    public class PaintingModel : PaintingAbstractModel
    {
        public PaintingModel()
        {
            Panel = new List<PanelModel>(); 
        }
        public List<PanelModel> Panel { get; set; }
    }
}