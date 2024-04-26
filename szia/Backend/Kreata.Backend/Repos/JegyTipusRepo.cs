using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class JegyTipusRepo<TDbContext> : RepositoryBase<TDbContext, JegyTipus>, IJegyTipusRepo
        where TDbContext : DbContext
    {
        public JegyTipusRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public IQueryable<JegyTipus> SelectAllIncluded()
        {
            return FindAll().Include(tipus => tipus.JegyTipusok);
        }

    }
}
