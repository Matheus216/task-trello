using System.Collections.Generic;
using trello.api.Models;

namespace trello.api.Service.Panel
{
    public interface IPanelService
    {
        IList<PanelModel> Get(); 
        IList<PanelModel> GetByPaitingId(int id); 
        PanelModel Save(PanelModel panel); 
        PanelModel UpdateDescription(int id, string description); 
        void Remove(int id); 
    }
}