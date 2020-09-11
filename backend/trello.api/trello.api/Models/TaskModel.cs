using System;

namespace trello.api.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public EnumStatus Status { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateFinished { get; set; }
        public string Estimated { get; set; }
    }
}