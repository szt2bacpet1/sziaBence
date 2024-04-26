using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class CountryTypeOfRepo<TDbContext> : RepositoryBase<TDbContext, CountryTypeOf>, ICountryTypeOfRepo
        where TDbContext : DbContext
    {
        public CountryTypeOfRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

}
