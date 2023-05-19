using Microsoft.EntityFrameworkCore;
using App.Domain;
using App.Persistence.Configurations;

namespace App.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; } = null!;
        public DbSet<Checklist> Checklists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ChecklistConfiguration());
        }
    }
}
