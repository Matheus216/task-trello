namespace trello.api.Repositories.Entities.Models
{
    public class TaskUserEntityModel
    {
        public int TaskId { get; set; }
        public TaskEntityModel Task { get; set; }
        public int UserId { get; set; }
        public UserEntityModel User { get; set; }
    }
}