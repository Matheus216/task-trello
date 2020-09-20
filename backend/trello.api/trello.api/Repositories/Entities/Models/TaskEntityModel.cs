
using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Repositories.Entities.Models
{
    public class TaskEntityModel : TaskAbstractModel
    {
        public PanelEntityModel Panel { get; set; }
        public ICollection<TaskUserEntityModel> TaskUser { get; set; }
        public ICollection<TaskCheckEntityModel> TaskCheck { get; set; }
    }
}