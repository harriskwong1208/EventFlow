namespace EventFlow.Models.DTO
{
    public class UpcomingRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
