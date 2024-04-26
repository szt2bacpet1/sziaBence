using Flyhigh.Shared.Models;

namespace Flyhigh.Backend.Repos
{
    public interface IGepAdatokTipusRepo : IRepositoryBase<GepAdatokTipus>
    {
        public IQueryable<GepAdatokTipus> SelectAllIncluded();

    }
}
