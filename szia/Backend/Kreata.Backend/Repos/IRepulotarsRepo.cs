using Flyhigh.Shared.Models;
using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Responses;

namespace Flyhigh.Backend.Repos
{
    public interface IRepulotarsRepo : IRepositoryBase<Repulotarsasag>
    {
        public IQueryable<Repulotarsasag> GetReptarsAdatok(RepulotarsasagQueryParameters parameters);
        public IQueryable<Repulotarsasag> SelectAllIncluded();
    }
}
