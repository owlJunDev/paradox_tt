using Backend.Configurations;
using Backend.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> noteTable { get; set; }
        public DbSet<Tag> tagTable { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}