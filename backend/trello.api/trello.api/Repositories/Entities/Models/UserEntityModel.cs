using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Repositories.Entities.Models
{
    public class UserEntityModel : UserAbstractModel
    {
        public List<TaskEntityModel> Task { get; set; }
    }
}