using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Context
{
    public class FlyhighMySqlContext : FlyhighContext
    {
        public FlyhighMySqlContext(DbContextOptions<FlyhighMySqlContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
