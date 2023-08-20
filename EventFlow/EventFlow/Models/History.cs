using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventFlow.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Completion { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
