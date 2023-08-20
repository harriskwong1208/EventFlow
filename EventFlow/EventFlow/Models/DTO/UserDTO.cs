using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
