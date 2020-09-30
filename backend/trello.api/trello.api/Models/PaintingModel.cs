using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Models
{
    public class PaintingModel : PaintingAbstractModel
    {
        public IList<PanelModel> Panel { get; set; }
    }
}