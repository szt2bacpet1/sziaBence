using Flyhigh.Backend.Context;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class RepulotarsRepo<TDbConstext> : RepositoryBase<TDbConstext, Repulotarsasag>, IRepulotarsRepo
       where TDbConstext : DbContext
    {
        public RepulotarsRepo(IDbContextFactory<TDbConstext> dbContextFactory) : base(dbContextFactory)
        {

        }
        public IQueryable<Repulotarsasag> GetReptarsAdatok(RepulotarsasagQueryParameters parameters)
        {
            IQueryable<Repulotarsasag> filteredReptars = FindByCondition(reptars =>
                reptars.LastName.Contains(parameters.Name) ||
                reptars.Country.Contains(parameters.Name));

            return filteredReptars;
        }

        public IQueryable<Repulotarsasag> SelectAllIncluded()
        {
            return FindAll().Include(reptars => reptars.Countries);
        }


        private void SearchByRepulotarsasagName(ref IQueryable<Repulotarsasag> repulotarsasags, string reptarsneve)
        {
            if (!repulotarsasags.Any() || string.IsNullOrEmpty(reptarsneve))
            {
                return;
            }
            repulotarsasags = repulotarsasags.Where(reptars => reptars.LastName.ToLower().Contains(reptarsneve.Trim().ToLower()));
        }
    }
}
