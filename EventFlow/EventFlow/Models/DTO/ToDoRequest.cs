namespace EventFlow.Models.DTO
{
    public class ToDoRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
