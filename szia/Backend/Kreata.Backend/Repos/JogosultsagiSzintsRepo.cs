using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class JogosultsagiSzintsRepo<TDbContext> : RepositoryBase<TDbContext, JogosultsagiSzints>, IJogosultsagiSzintsRepo
        where TDbContext : DbContext
    {
        public JogosultsagiSzintsRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public IQueryable<JogosultsagiSzints> SelectAllIncluded()
        {
            return FindAll().Include(tipus => tipus.AllJogosultsagiSzints);
        }
    }
}
