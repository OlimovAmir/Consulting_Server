using Consulting_Server.Models;
using Consulting_Server.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace Consulting_Server.Infrastructure
{
    public class MemoryContext : DbContext
    {
        public MemoryContext(DbContextOptions<MemoryContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }
        public DbSet<MessageFromUser> MessageFromUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseEntity>();

            modelBuilder.Entity<MessageFromUser>()
                .HasKey(u => u.Id); // Указание первичного ключа для сущности Unit


            base.OnModelCreating(modelBuilder);

        }

    }
}
