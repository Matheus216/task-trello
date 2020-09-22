namespace trello.api.Models.Abstract
{
    public class CheckAbstractModel
    {
        public int CheckId { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
        public int TaskId { get; set; }
    }
}