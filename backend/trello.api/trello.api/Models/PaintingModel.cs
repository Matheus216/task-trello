using System.Collections.Generic;

namespace trello.api.Models
{
    public class PaintingModel
    {
        public int PaintingId { get; set; }
        public string Description { get; set; }
        public IList<PanelModel> Panel { get; set; }
    }
}