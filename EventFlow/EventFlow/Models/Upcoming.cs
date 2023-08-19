using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventFlow.Models
{
    public class Upcoming
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
