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
    }
}
