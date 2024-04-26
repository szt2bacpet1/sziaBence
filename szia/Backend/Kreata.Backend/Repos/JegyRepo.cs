using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class JegyRepo<TDbContext> : RepositoryBase<TDbContext, Jegy>, IJegyRepo
      where TDbContext : DbContext
    {
        public JegyRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }


        public IQueryable<Jegy> GetJegyek()
        {
            return FindAll().Include(j =>j.JegyTipus);
        }
    }
}
