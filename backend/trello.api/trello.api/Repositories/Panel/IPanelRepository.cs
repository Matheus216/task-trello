using System.Collections.Generic;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.Panel
{
    public interface IPanelRepository : IRepository<PanelEntityModel>
    {
        IList<PanelEntityModel> GetByPaitingId(int id);
    }
}