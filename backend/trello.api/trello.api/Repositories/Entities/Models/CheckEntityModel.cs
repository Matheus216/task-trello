using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Repositories.Entities.Models
{
    public class CheckEntityModel : CheckAbstractModel
    {
        public ICollection<TaskCheckEntityModel> Task { get; set; }
    }
}