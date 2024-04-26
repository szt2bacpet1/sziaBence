using Flyhigh.Shared.Models;

namespace Flyhigh.Backend.Repos
{
    public interface IJegyRepo : IRepositoryBase<Jegy>
    {
        public IQueryable<Jegy> GetJegyek();


    }
}
