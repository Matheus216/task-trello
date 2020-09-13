
using trello.api.Models.Abstract;

namespace trello.api.Repositories.Entities.Models
{
    public class TaskEntityModel : TaskAbstractModel
    {
        public PanelEntityModel Panel { get; set; }
    }
}