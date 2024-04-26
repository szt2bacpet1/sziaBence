using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Flyhigh.Shared.Parameters;


namespace Flyhigh.Backend.Repos
{
    public interface IFelhasznaloRepo : IRepositoryBase<Felhasznalo>
    {
        public IQueryable<Felhasznalo> GetFelhasznalo(FelhasznaloQueryParameters parameters);
        public IQueryable<Felhasznalo> SelectAllIncluded();

    }
}
