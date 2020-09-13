using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Models
{
    public class PanelModel : PanelAbstractModel
    {
        public PanelModel()
        {
            Task = new List<TaskModel>();
        }
        public List<TaskModel> Task { get; set; }
    }
}