using Flyhigh.Backend.Context;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Flyhigh.Shared.Parameters;

namespace Flyhigh.Backend.Repos
{
    public class GepRepo<TDbContext> : RepositoryBase<TDbContext, GepAdatok>, IGepRepo
       where TDbContext : DbContext
    {
        public GepRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }


        public IQueryable<GepAdatok> GetGepAdatok()
        {
            return FindAll().Include(gep => gep.GepAdatokTipus);
        }

        public IQueryable<GepAdatok> SelectGepekByTipusId(Guid tipusID)
        {
            return FindAll().Where(gep => gep.GepAdatokTipusId == tipusID);
        }

        public IQueryable<GepAdatok> SelectGepekWithoutTipus()
        {
            return FindAll().Where(gep =>gep.GepAdatokTipusId == null ||gep.GepAdatokTipusId == Guid.Empty);
        }

        //public IQueryable<GepAdatok> GetGepAdatok(GepAdatokQueryParameters parameters)
        //{
        //    IQueryable<GepAdatok> filteredGepek = FindByCondition(gepek => gepek.Foglaltturista >= parameters.MinFoglaltTurista
        //                                                        && gepek.Foglaltturista <= parameters.MaxFoglaltTurista
        //                                                          )
        //                                           .OrderBy(gepek => gepek.Gepneve);

        //    SearchByGepAdatokName(ref filteredGepek, parameters.Name);
        //    return filteredGepek;
        //}
        private void SearchByGepAdatokName(ref IQueryable<GepAdatok> gepeks, string gepekneve)
        {
            if (!gepeks.Any() || string.IsNullOrEmpty(gepekneve))
            {
                return;
            }
            gepeks = gepeks.Where(gepek => gepek.Gepneve.ToLower().Contains(gepekneve.Trim().ToLower()));
        }

    }
}
