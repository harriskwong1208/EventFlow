using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string  Name{ get; set; }
        public string Password { get; set; }

        public ICollection<Upcoming> Upcomings { get; set; }
        public ICollection<ToDo> ToDos { get; set; }
        public ICollection<History> Histories { get; set; }
    }
}
