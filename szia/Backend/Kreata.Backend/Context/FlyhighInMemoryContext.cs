using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Context
{
    public class FlyhighInMemoryContext : FlyhighContext
    {
        public FlyhighInMemoryContext(DbContextOptions<FlyhighInMemoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

    }
}
