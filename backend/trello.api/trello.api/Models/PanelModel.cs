using System.Collections.Generic;

namespace trello.api.Models
{
    public class PanelModel
    {
        public PanelModel(IList<TaskModel> task)
        {
            Task = task;
        }
        public int PanelId { get; set; }   
        public string Description { get; set; } 
        public string Title { get; set; }
        public IList<TaskModel> Task { get; set; }

        public int TaskId { get; set; }
    }
}