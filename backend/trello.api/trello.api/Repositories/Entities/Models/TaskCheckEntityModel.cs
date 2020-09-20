namespace trello.api.Repositories.Entities.Models
{
    public class TaskCheckEntityModel
    {
        public int CheckId { get; set; }
        public CheckEntityModel Check { get; set; }
        public int TaskId { get; set; }
        public TaskEntityModel Task { get; set; }
    }
}