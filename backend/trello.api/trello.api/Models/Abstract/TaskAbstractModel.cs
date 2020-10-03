using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello.api.Models.Abstract
{
    public abstract class TaskAbstractModel
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public EnumStatus Status { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateFinished { get; set; }
        public string Estimated { get; set; }
        public int PanelId { get; set; }
        public string Title { get; set; }
    }
}