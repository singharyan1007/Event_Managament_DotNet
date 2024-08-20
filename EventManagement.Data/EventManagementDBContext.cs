
using Microsoft.EntityFrameworkCore;
using EventManagement.Domain.Entities;
namespace EventManagement.Data
{
    public class EventManagementDBContext : DbContext
    {
        public EventManagementDBContext(DbContextOptions<EventManagementDBContext> options) : base(options)
        { }

        public EventManagementDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EventManageDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }



    }
}
