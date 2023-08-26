using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models.DTO
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Completion { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
    }
}
