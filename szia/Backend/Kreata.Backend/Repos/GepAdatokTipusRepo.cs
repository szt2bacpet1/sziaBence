using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class GepAdatokTipusRepo<TDbContext> : RepositoryBase<TDbContext, GepAdatokTipus>, IGepAdatokTipusRepo
        where TDbContext : DbContext
    {
        public GepAdatokTipusRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public IQueryable<GepAdatokTipus> SelectAllIncluded()
        {
            return FindAll().Include(tipus => tipus.GepekTipus);
        }
    }
}
