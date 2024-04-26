using Flyhigh.Backend.Context;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class FelhasznaloRepo<TDbConstext> : RepositoryBase<TDbConstext, Felhasznalo>, IFelhasznaloRepo
       where TDbConstext : DbContext
    {
        public FelhasznaloRepo(IDbContextFactory<TDbConstext> dbContextFactory) : base(dbContextFactory)
        {

        }
        public IQueryable<Felhasznalo> GetFelhasznalo(FelhasznaloQueryParameters parameters)
        {

              IQueryable<Felhasznalo> filteredFelhasznalo = FindByCondition(felhasznalo => felhasznalo.LastName == parameters.Name);


            return filteredFelhasznalo;
        }

        private void SearchByFelhasznaloName(ref IQueryable<Felhasznalo> felhasznalos, string felhasznaloneve)
        {
            if (!felhasznalos.Any() || string.IsNullOrEmpty(felhasznaloneve))
            {
                return;
            }
            felhasznalos = felhasznalos.Where(felhasznalo => felhasznalo.LastName.ToLower().Contains(felhasznaloneve.Trim().ToLower()));
        }

        public IQueryable<Felhasznalo> SelectAllIncluded()
        {
            return FindAll().Include(el => el.JogosultsagiSzint);
        }
    }
}
