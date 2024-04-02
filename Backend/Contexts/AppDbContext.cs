using Backend.Models;
using Microsoft.EntityFrameworkCore;
 
namespace Backend.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> noteTable { get; set; }
        public DbSet<Tag> tagTable { get; set; }
        public DbSet<NoteTag> noteTagTable { get; set; }
        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;" +
                                    "Port=5432;" +
                                    "Database=notes;" +
                                    "Username=postgres;" +
                                    "Password=postgres");
        }
    }
}