using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Flyhigh.Shared.Parameters;

namespace Flyhigh.Backend.Repos
{
    public interface IGepRepo : IRepositoryBase<GepAdatok>
    {
        //public IQueryable<GepAdatok> GetGepAdatok(GepAdatokQueryParameters parameters);

        public IQueryable<GepAdatok> GetGepAdatok();
        public IQueryable<GepAdatok> SelectGepekByTipusId(Guid tipusID);

        IQueryable<GepAdatok> SelectGepekWithoutTipus();


    }

}
