using Flyhigh.Shared.Models;

namespace Flyhigh.Backend.Repos
{
    public interface IJegyTipusRepo : IRepositoryBase<JegyTipus>
    {
        public IQueryable<JegyTipus> SelectAllIncluded();

    }
}