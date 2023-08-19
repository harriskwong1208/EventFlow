using EventFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Upcoming> Upcomings { get; set; }
    }
}
