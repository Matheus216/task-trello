using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello.api.Models.Abstract
{
    public abstract class PanelAbstractModel
    {
        public int PanelId { get; set; }   
        public string Description { get; set; } 
        public string Title { get; set; }
    }
}