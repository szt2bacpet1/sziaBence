using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class CountriesRepo<TDbContext> : RepositoryBase<TDbContext, Countries>,
        ICountriesRepo where TDbContext : DbContext
    {
        public CountriesRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
        public IQueryable<Countries> SelectAllIncluded()
        {
            return FindAll().Include(countries => countries.Repulotarsasags);
        }

    }

}
